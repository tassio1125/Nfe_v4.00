﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using NFe.Components.Abstract;
using NFe.Components.br.gov.pr.londrina.testeiss.h;

namespace NFe.Components.SigCorp.LondrinaPR.h
{
    public class SigCorpH : EmiteNFSeBase
    {
        ModuloEmissorNFSe service = new ModuloEmissorNFSe();

        #region construtores
        public SigCorpH(TipoAmbiente tpAmb, string pastaRetorno)
            : base(tpAmb, pastaRetorno)
        {

        }
        #endregion

        #region Métodos
        public override void EmiteNF(string file)
        {
            tcDescricaoRps oTcDescricaoRps = ReadXML<tcDescricaoRps>(file);
            tcEstruturaDescricaoErros[] tcErros = null;
            tcRetornoNota result = service.GerarNota(oTcDescricaoRps, out tcErros);
            string strResult = base.CreateXML(result, tcErros);
            GerarRetorno(file, strResult, Propriedade.ExtEnvio.EnvLoteRps, Propriedade.ExtRetorno.LoteRps);
        }

        public override void CancelarNfse(string file)
        {
            tcDescricaoCancelaNota oTcDadosCancela = ReadXML<tcDescricaoCancelaNota>(file);
            tcEstruturaDescricaoErros[] tcErros = null;
            tcRetornoNota result = service.CancelarNota(oTcDadosCancela, out tcErros);
            string strResult = base.CreateXML(result, tcErros);
            GerarRetorno(file, strResult, Propriedade.ExtEnvio.PedCanNfse, Propriedade.ExtRetorno.retCancelamento_XML);
        }

        public override void ConsultarLoteRps(string file)
        {
            tcConsultarRpsServicoPrestadoEnvio oTcDadosConsultaNota = ReadXML<tcConsultarRpsServicoPrestadoEnvio>(file);
            tcEstruturaDescricaoErros[] tcErros = null;

            string result = service.ConsultarRpsServicoPrestado(oTcDadosConsultaNota, out tcErros);
            string strResult = result;
            GerarRetorno(file, strResult, Propriedade.ExtEnvio.PedLoteRps, Propriedade.ExtRetorno.RetLoteRps);
        }

        public override void ConsultarSituacaoLoteRps(string file)
        {
            throw new Exceptions.ServicoInexistenteException();
        }

        public override void ConsultarNfse(string file)
        {
            tcConsultarNfseServicoPrestadoEnvio oTcDadosPrestador = ReadXML<tcConsultarNfseServicoPrestadoEnvio>(file);
            tcEstruturaDescricaoErros[] tcErros = null;
            string strResult = service.ConsultarNfseServicoPrestado(oTcDadosPrestador, out tcErros);
            GerarRetorno(file, strResult, Propriedade.ExtEnvio.PedSitNfse, Propriedade.ExtRetorno.SitNfse);
        }

        public override void ConsultarNfsePorRps(string file)
        {
            throw new Exceptions.ServicoInexistenteException();
        }
        

        private T ReadXML<T>(string file)
            where T : new()
        {
            T result = new T();
            result = (T)ReadXML2(file, result, result.GetType().Name.Substring(2));
            return result;
        }

        private object ReadXML2(string file, object value, string tag)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(file);
            XmlNodeList nodes = doc.GetElementsByTagName(tag);
            XmlNode node = nodes[0];

            foreach (XmlNode n in node)
            {
                if (n.NodeType == XmlNodeType.Element)
                {
                    SetProperrty(value, n.Name, n.InnerXml);
                }
            }

            return value;
        }

        private int NumeroNota(string file, string tag)
        {
            int nNumeroNota = 0;
            XmlDocument doc = new XmlDocument();
            doc.Load(file);
            XmlNodeList nodes = doc.GetElementsByTagName(tag);
            XmlNode node = nodes[0];

            foreach (XmlNode n in node)
            {
                if (n.NodeType == XmlNodeType.Element)
                {
                    if (n.Name.Equals("Nota"))
                    {
                        nNumeroNota = Convert.ToInt32(n.InnerText);
                        break;
                    }
                }
            }

            return nNumeroNota;
        }

        private void SetProperrty(object result, string propertyName, object value)
        {
            PropertyInfo pi = result.GetType().GetProperty(propertyName);

            if (pi != null)
            {
                value = Convert.ChangeType(value, pi.PropertyType);
                pi.SetValue(result, value, null);
            }
        }
        #endregion
    }
}
