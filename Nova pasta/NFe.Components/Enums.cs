﻿using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace NFe.Components
{
    #region SubPastas da pasta de enviados
    /// <summary>
    /// SubPastas da pasta de XML´s enviados para os webservices
    /// </summary>
    public enum PastaEnviados
    {
        EmProcessamento,
        Autorizados,
        Denegados
    }
    #endregion

    #region Servicos
    /// <summary>
    /// Serviços executados pelo Aplicativo
    /// </summary>
    public enum Servicos
    {
        #region NFe
        /// <summary>
        /// Consulta status serviço NFe
        /// </summary>
        NFeConsultaStatusServico,
        /// <summary>
        /// Somente converter TXT da NFe para XML de NFe
        /// </summary>
        NFeConverterTXTparaXML,
        /// <summary>
        /// Envia os lotes de NFe para os webservices (NfeRecepcao)
        /// </summary>
        NFeEnviarLote,
        /// <summary>
        /// Envia os lotes de NFe para os webservices (NFeAutorizacao)
        /// </summary>
        NFeEnviarLote2,
        /// <summary>
        /// Envia os lotes de NFe para os webservices de forma Compactada (NFeAutorizacao)
        /// </summary>
        NFeEnviarLoteZip2,
        /// <summary>
        /// Envia XML de Inutilização da NFe
        /// </summary>
        NFeInutilizarNumeros,
        /// <summary>
        /// Assinar e montar lote de uma NFe
        /// </summary>
        NFeMontarLoteUma,
        /// <summary>
        /// Consulta situação da NFe
        /// </summary>
        NFePedidoConsultaSituacao,
        /// <summary>
        /// Consulta recibo do lote nfe (NFeRetRecepcao)
        /// </summary>
        NFePedidoSituacaoLote,
        /// <summary>
        /// Consulta recibo do lote nfe (NFeRetAutorizacao)
        /// </summary>
        NFePedidoSituacaoLote2,

        #region Eventos NFe
        /// <summary>
        /// Enviar XML Evento - Cancelamento
        /// </summary>
        EventoCancelamento,
        /// <summary>
        /// Enviar XML Evento - Carta de Correção
        /// </summary>
        EventoCCe,
        /// <summary>
        /// Enviar um evento de EPEC
        /// </summary>
        EventoEPEC,
        /// <summary>
        /// Enviar um evento de manifestacao
        /// </summary>
        EventoManifestacaoDest,
        /// <summary>
        /// Enviar XML de Evento NFe
        /// </summary>
        EventoRecepcao,
        #endregion

        /// <summary>
        /// Assinar e validar um XML de NFe no envio em Lote
        /// </summary>
        NFeAssinarValidarEnvioEmLote,
        /// <summary>
        /// Enviar uma consulta de nfe de destinatario
        /// </summary>
        NFeConsultaNFDest,
        /// <summary>
        /// Enviar solicitacao de download de nfe
        /// </summary>
        NFeDownload,
        /// <summary>
        /// Monta chave de acesso
        /// </summary>
        NFeGerarChave,
        /// <summary>
        /// Assinar e montar lote de várias NFe
        /// </summary>
        NFeMontarLoteVarias,
        /// <summary>
        /// Consultar o registro do DPEC no SCE - Sistema de Contingência Eletrônica        
        /// </summary>
        DPECConsultar,
        /// <summary>
        /// Enviar o XML do DPEC para o SCE - Sistema de Contingência Eletrônica
        /// </summary>
        DPECEnviar,
        #endregion

        #region CTe
        /// <summary>
        /// Assinar e validar um XML de CTe no envio em Lote
        /// </summary>
        CTeAssinarValidarEnvioEmLote,
        /// <summary>
        /// Consulta Status Serviço CTe
        /// </summary>
        CTeConsultaStatusServico,
        /// <summary>
        /// Envia os lotes de CTe para os webservices
        /// </summary>
        CTeEnviarLote,
        /// <summary>
        /// Envia XML de Inutilização da CTe
        /// </summary>
        CTeInutilizarNumeros,
        /// <summary>
        /// Montar lote de um CTe
        /// </summary>
        CTeMontarLoteUm,
        /// <summary>
        /// Assinar e montar lote de várias CTe
        /// </summary>
        CTeMontarLoteVarios,
        /// <summary>
        /// Consulta situação da CTe
        /// </summary>
        CTePedidoConsultaSituacao,
        /// <summary>
        /// Consulta recibo do lote CTe
        /// </summary>
        CTePedidoSituacaoLote,
        /// <summary>
        /// Enviar XML Evento CTe
        /// </summary>
        CTeRecepcaoEvento,
        #endregion

        #region NFSe
        /// <summary>
        /// Cancelar NFS-e
        /// </summary>
        [Description("Cancelar NFS-e")]
        NFSeCancelar,
        /// <summary>
        /// Consultar NFS-e por Data
        /// </summary>
        [Description("Consultar NFS-e por Data")]
        NFSeConsultar,
        /// <summary>
        /// Consultar lote RPS
        /// </summary>
        [Description("ConsultarLoteRPS")]
        NFSeConsultarLoteRps,
        /// <summary>
        /// Consultar NFS-e por RPS
        /// </summary>
        [Description("Consultar NFS-e por RPS")]
        NFSeConsultarPorRps,
        /// <summary>
        /// Consultar Situação do lote RPS NFS-e
        /// </summary>
        [Description("Consultar Situação do lote RPS NFS-e")]
        NFSeConsultarSituacaoLoteRps,
        /// <summary>
        /// Consultar a URL de visualização da NFSe
        /// </summary>
        [Description("Consultar a URL de Visualização da NFS-e")]
        NFSeConsultarURL,
        /// <summary>
        /// Consultar a URL de visualização da NFSe
        /// </summary>
        [Description("Consultar a URL de Visualização da NFS-e com a Série")]
        NFSeConsultarURLSerie,
        /// <summary>
        /// Enviar Lote RPS NFS-e 
        /// </summary>
        [Description("Enviar Lote RPS NFS-e ")]
        NFSeRecepcionarLoteRps,
        /// <summary>
        /// Enviar Lote RPS NFS-e de forma sincrona 
        /// Criado inicialmente para ser utilizado para o padrão BHIss, pois é necessario utilizar a recepção de lote das duas formas.
        /// </summary>
        [Description("Enviar Lote RPS NFS-e Sincrono")]
        NFSeRecepcionarLoteRpsSincrono,
        /// <summary>
        /// Consulta da imagem de uma NFS-e em formato PNG
        /// Criado inicialmente para ser utilizado para o padrão INFISC para a Prefeitura de Caxias do Sul - RS
        /// </summary>
        [Description("Consulta da imagem de uma NFS-e em formato PNG")]
        NFSeConsultarNFSePNG,
        /// <summary>
        /// Consulta da imagem de uma NFS-e em formato 
        /// Criado inicialmente para ser utilizado para o padrão INFISC para a Prefeitura de Caxias do Sul - RS
        /// </summary>
        [Description("Inutilização de uma NFS-e")]
        NFSeInutilizarNFSe,

        #endregion

        #region MDFe
        /// <summary>
        /// Assinar e validar um XML de MDFe no envio em Lote
        /// </summary>
        MDFeAssinarValidarEnvioEmLote,
        /// <summary>
        /// Consulta MDFe nao encerrados
        /// </summary>
        MDFeConsultaNaoEncerrado,
        /// <summary>
        /// Consulta Status Serviço MDFe
        /// </summary>
        MDFeConsultaStatusServico,
        /// <summary>
        /// Envia os lotes de MDFe para os webservices
        /// </summary>
        MDFeEnviarLote,
        /// <summary>
        /// Montar lote de um MDFe
        /// </summary>
        MDFeMontarLoteUm,
        /// <summary>
        /// Assinar e montar lote de várias MDFe
        /// </summary>
        MDFeMontarLoteVarios,
        /// <summary>
        /// Consulta situação da MDFe
        /// </summary>
        MDFePedidoConsultaSituacao,
        /// <summary>
        /// Consulta recibo do lote MDFe
        /// </summary>
        MDFePedidoSituacaoLote,
        /// <summary>
        /// Enviar XML Evento MDFe
        /// </summary>
        MDFeRecepcaoEvento,
        #endregion

        #region Serviços em comum NFe, CTe, MDFe e NFSe
        /// <summary>
        /// Valida e envia o XML de pedido de Consulta do Cadastro do Contribuinte para o webservice
        /// </summary>
        ConsultaCadastroContribuinte,
        /// <summary>
        /// Efetua verificações nas notas em processamento para evitar algumas falhas e perder retornos de autorização de notas
        /// </summary>
        EmProcessamento,
        /// <summary>
        /// Somente assinar e validar o XML
        /// </summary>
        AssinarValidar,
        #endregion

        #region Serviços gerais
        /// <summary>
        /// Consultar Informações Gerais do UniNFe
        /// </summary>
        UniNFeConsultaInformacoes,
        /// <summary>
        /// Solicitar ao UniNFe que altere suas configurações
        /// </summary>
        UniNFeAlterarConfiguracoes,
        /// <summary>
        /// Efetua uma limpeza das pastas que recebem arquivos temporários
        /// </summary>
        UniNFeLimpezaTemporario,
        /// <summary>
        /// Consultas efetuadas pela pasta GERAL.
        /// </summary>
        UniNFeConsultaGeral,
        /// <summary>
        /// Consulta Certificados Instalados na estação do UniNFe.
        /// </summary>
        UniNFeConsultaCertificados,
        #endregion

        #region Não sei para que serve - Wandrey
        /// <summary>
        /// WSExiste
        /// </summary>
        WSExiste,
        #endregion

        #region Impressao do DANFE
        DANFEImpressao,
        DANFEImpressao_Contingencia,
        #endregion

        #region Impressao do relatorio de e-mails do DANFE
        DANFERelatorio,
        #endregion

        DFeEnviar,

        /// <summary>
        /// Nulo / Nenhum serviço em execução
        /// </summary>        
        Nulo
    }
    #endregion

    #region TipoAplicativo
    public enum TipoAplicativo
    {
        /// <summary>
        /// Aplicativo ou serviços para processamento dos XMLs da NF-e e NFC-e
        /// </summary>
        /// 
        [Description("NF-e e NFC-e")]
        Nfe = 0,
        /// <summary>
        /// Aplicativo ou serviços para processamento dos XMLs do CT-e
        /// </summary>
        [Description("CT-e")]
        Cte = 1,
        /// <summary>
        /// Aplicativo ou servicos para processamento dos XMLs da NFS-e
        /// </summary>
        [Description("NFS-e")]
        Nfse = 2,
        /// <summary>
        /// Aplicativo ou serviços para processamento dos XMLs do MDF-e
        /// </summary>
        [Description("MDF-e")]
        MDFe = 3,
        /// <summary>
        /// Aplicativo ou serviços para processamento dos XMLs da NFC-e
        /// </summary>
        [Description("NFC-e")]
        NFCe = 4,
        [Description("NF-e, NFC-e, CT-e e MDF-e")]
        Todos = 10,
        [Description("")]
        Nulo = 100
    }
    #endregion

    #region Padrão NFSe
    public enum PadroesNFSe
    {
        /// <summary>
        /// Não Identificado
        /// </summary>
        [Description("Não identificado")]
        NaoIdentificado,
        /// <summary>
        /// Padrão GINFES
        /// </summary>
        [Description("GINFES")]
        GINFES,
        /// <summary>
        /// Padrão da BETHA Sistemas
        /// </summary>
        [Description("BETHA")]
        BETHA,
        /// <summary>
        /// Padrão da THEMA Informática
        /// </summary>
        [Description("THEMA")]
        THEMA,
        /// <summary>
        /// Padrão da prefeitura de Salvador-BA
        /// </summary>
        [Description("Salvador-BA")]
        SALVADOR_BA,
        /// <summary>
        /// Padrão da prefeitura de Canoas-RS
        /// </summary>
        [Description("Canoas-RS")]
        CANOAS_RS,
        /// <summary>
        /// Padrão da ISS Net
        /// </summary>    
        [Description("ISS Net")]
        ISSNET,
        /// <summary>
        /// Padrão da prefeitura de Apucarana-PR
        /// Padrão da prefeitura de Aracatuba-SP
        /// </summary>
        [Description("ISS On-line")]
        ISSONLINE,
        /// <summary>
        /// Padrão da prefeitura de Blumenau-SC
        /// </summary>
        [Description("Blumenau-SC")]
        BLUMENAU_SC,
        /// <summary>
        /// Padrão da prefeitura de Juiz de Fora-MG
        /// </summary>
        [Description("BHISS")]
        BHISS,
        /// <summary>
        /// Padrao GIF
        /// Prefeitura de Campo Bom-RS
        /// </summary>
        [Description("GIF/Infisc")]
        GIF,
        /// <summary>
        /// Padrão IPM
        /// <para>Prefeitura de Campo Mourão.</para>
        /// </summary>
        [Description("IPM")]
        IPM,
        /// <summary>
        /// Padrão DUETO
        /// Prefeitura de Nova Santa Rita - RS
        /// </summary>
        [Description("Dueto")]
        DUETO,
        /// <summary>
        /// Padrão WEB ISS
        /// Prefeitura de Feira de Santana - BA
        /// </summary>
        [Description("Web ISS")]
        WEBISS,
        /// <summary>
        /// Padrão Nota Fiscal Eletrônica Paulistana -
        /// Prefeitura São Paulo - SP
        /// </summary>
        [Description("Paulistana")]
        PAULISTANA,
        /// <summary>
        /// Padrão Nota Fiscal Eletrônica Porto Velhense
        /// Prefeitura de Porto Velho - RO
        /// </summary>
        [Description("Portovelhense")]
        PORTOVELHENSE,
        /// <summary>
        /// Padrão Nota Fiscal Eletrônica da PRONIN (GovBR)
        /// Prefeitura de Mirassol - SP
        /// </summary>
        [Description("Pronin")]
        PRONIN,
        /// <summary>
        /// Padrão Nota Fiscal Eletrônica ISS-ONline da 4R Sistemas
        /// Prefeitura de Governador Valadares - SP
        /// </summary>
        [Description("ISS On-Line/4R")]
        ISSONLINE4R,
        /// <summary>
        /// Padrão Nota Fiscal eletrônica DSF 
        /// Prefeitura de Campinas - SP
        /// Prefeitura de Campo Grande - MS
        /// </summary>
        [Description("DSF")]
        DSF,
        /// <summary>
        /// Padrão Tecno Sistemas
        /// Prefeitura de Portão - RS
        /// </summary>
        [Description("Tecno Sistemas")]
        TECNOSISTEMAS,
        /// <summary>
        /// Padrão System-PRO
        /// Prefeitura de Erechim - RS
        /// </summary>
        [Description("System-Pro")]
        SYSTEMPRO,
        /// <summary>
        /// Preifetura de Macaé - RJ
        /// </summary>
        [Description("Tiplan")]
        TIPLAN,
        /// <summary>
        /// Prefeitura do Rio de Janeiro - RJ
        /// </summary>
        [Description("Carioca")]
        CARIOCA,
        /// <summary>
        /// Prefeitura de Bauru - SP
        /// </summary>
        [Description("SigCorp/SigISS")]
        SIGCORP_SIGISS,
        /// <summary>
        /// Padrão SmaraPD
        /// Prefeitura de Sertãozinho - SP
        /// </summary>
        [Description("SmaraPD")]
        SMARAPD,
        /// <summary>
        /// Padrão Fiorilli
        /// Prefeitura de Taquara - SP
        /// </summary>
        [Description("Fiorilli")]
        FIORILLI,
        /// <summary>
        /// Padrão Fintel
        /// Prefeitura de Ponta Grossa - PR
        /// </summary>
        [Description("Fintel")]
        FINTEL,
        /// <summary>
        /// Padrão ISSWEB
        /// Prefeitura de Mairipora - SP
        /// </summary>
        [Description("ISSWeb")]
        ISSWEB,
        /// <summary>
        /// Padrão SimplIss
        /// Prefeitura de Piracicaba - SP
        /// </summary>
        [Description("SimplIss")]
        SIMPLISS,
        /// <summary>
        /// Padrão Conam
        /// Prefeitura de Varginha - MG
        /// </summary>
        [Description("CONAM")]
        CONAM,
        /// <summary>
        /// Padrão Rlz Informatica
        /// Prefeitura de Santa Fé do Sul - PR
        /// </summary>
        [Description("Rlz Informática")]
        RLZ_INFORMATICA,
        /// <summary>
        /// Padrão E-Governe
        /// Prefeitura de Curitiba - PR
        /// </summary>
        [Description("E-Governe")]
        EGOVERNE

        ///Atencao Wandrey.
        ///o nome deste enum tem que coincidir com o nome da url, pq faço um "IndexOf" deste enum para pegar o padrao

    }
    #endregion

    #region Classe dos tipos de ambiente da NFe
    /// <summary>
    /// Tipo de ambiente
    /// </summary>
    public enum TipoAmbiente
    {
        [Description("Produção")]
        taProducao = 1,
        [Description("Homologação")]
        taHomologacao = 2
    }
    #endregion

    #region TipoEmissao
    /// <summary>
    /// TipoEmissao
    /// </summary>
    public enum TipoEmissao
    {
        [Description("")]
        teNone = 0,
        [Description("Normal")]
        teNormal = 1,
        [Description("Contingência com formulário de segurança (FS)")]
        teFS = 2,
        [Description("Contingência com EPEC / DPEC")]
        teEPECeDPEC = 4,
        [Description("Contingência com formulário de segurança (FS-DA)")]
        teFSDA = 5,
        [Description("Contingência com SVC-AN")]
        teSVCAN = 6,
        [Description("Contingência com SVC-RS")]
        teSVCRS = 7,
        [Description("Contingência com SVC-SP")]
        teSVCSP = 8,
        [Description("Contingência Off-Line (NFC-e)")]
        teOffLine = 9
    }
    #endregion

    #region Erros Padrões
    public enum ErroPadrao
    {
        ErroNaoDetectado = 0,
        FalhaInternet = 1,
        FalhaEnvioXmlWS = 2,
        CertificadoVencido = 3,
        FalhaEnvioXmlWSDPEC = 4, //danasa 21/10/2010
        FalhaEnvioXmlNFeWS = 5
    }
    #endregion

    #region EnumHelper

    /*
ComboBox combo = new ComboBox();
combo.DataSource = EnumHelper.ToList(typeof(SimpleEnum));
combo.DisplayMember = "Value";
combo.ValueMember = "Key";
    
        foreach (string value in Enum.GetNames(typeof(Model.TipoCampanhaSituacao)))
        {
            Model.TipoCampanhaSituacao stausEnum = (Model.TipoCampanhaSituacao)Enum.Parse(typeof(Model.TipoCampanhaSituacao), value);
            Console.WriteLine(" Description: " + value+"  "+ Model.EnumHelper.GetDescription(stausEnum));
        }
     
 */

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public sealed class AttributeTipoAplicacao : Attribute
    {
        private TipoAplicativo aplicacao;
        public TipoAplicativo Aplicacao
        {
            get
            {
                return this.aplicacao;
            }
        }

        public AttributeTipoAplicacao(TipoAplicativo aplicacao)
            : base()
        {
            this.aplicacao = aplicacao;
        }
    }

    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class EnumDescriptionAttribute : Attribute
    {
        private string description;
        public string Description
        {
            get
            {
                return this.description;
            }
        }

        public EnumDescriptionAttribute(string description)
            : base()
        {
            this.description = description;
        }
    }

    /// <summary>
    /// Classe com metodos para serem utilizadas nos Enuns
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Retorna a description do enum
        /// </summary>
        /// <param name="value">Enum para buscar a description</param>
        /// <returns>Retorna a description do enun</returns>
        /*public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            DescriptionAttribute attribute
                    = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))
                        as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }*/




        public static T StringToEnum<T>(string name) { return (T)Enum.Parse(typeof(T), name, true); }

        /// <summary>
        /// Gets the <see cref="DescriptionAttribute"/> of an <see cref="Enum"/> type value.
        /// </summary>
        /// <param name="value">The <see cref="Enum"/> type value.</param>
        /// <returns>A string containing the text of the <see cref="DescriptionAttribute"/>.</returns>
        public static string GetDescription(Enum value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            string description = value.ToString();
            FieldInfo fieldInfo = value.GetType().GetField(description);
            EnumDescriptionAttribute[] attributes = (EnumDescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);
            if (attributes != null && attributes.Length > 0)
            {
                description = attributes[0].Description;
            }
            else
            {
                return GetEnumItemDescription(value);
                //DescriptionAttribute[] dattributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                //if (dattributes != null && dattributes.Length > 0)
                //description = dattributes[0].Description;
            }
            return description;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static string GetEnumItemDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        /// <summary>
        ///  Converts the <see cref="Enum"/> type to an <see cref="IList"/> compatible object.
        /// </summary>
        /// <param name="type">The <see cref="Enum"/> type.</param>
        /// <returns>An <see cref="IList"/> containing the enumerated type value and description.</returns>
        public static IList ToList(Type type, bool returnInt, bool excluibrancos)
        {
            return ToList(type, returnInt, excluibrancos, "");
        }

        public static IList ToList(Type type, bool returnInt, bool excluibrancos, string eliminar)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            ArrayList list = new ArrayList();
            Array enumValues = Enum.GetValues(type);

            foreach (Enum value in enumValues)
            {
                string _descr = GetDescription(value);
                if (excluibrancos && string.IsNullOrEmpty(_descr)) continue;

                if (eliminar.IndexOf(Convert.ToInt32(value).ToString()) != -1) continue;

                if (returnInt)
                    list.Add(new KeyValuePair<int, string>(Convert.ToInt32(value), _descr));
                else
                    list.Add(new KeyValuePair<Enum, string>(value, _descr));
            }

            return list;
        }

        public static IList ToStrings(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            ArrayList list = new ArrayList();
            Array enumValues = Enum.GetValues(type);

            foreach (Enum value in enumValues)
            {
                list.Add(GetDescription(value));
            }

            return list;
        }
    }

    #endregion
}
