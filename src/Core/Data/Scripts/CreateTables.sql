CREATE TABLE IF NOT EXISTS public."Cnaes" (
    "Codigo" text NOT NULL,
    "Descricao" text NOT NULL
);

ALTER TABLE public."Cnaes" OWNER TO postgres;

CREATE TABLE IF NOT EXISTS public."Empresas" (
    "CnpjBasico" text NOT NULL,
    "RazaoSocial" text NOT NULL,
    "NaturezaJuridica" text NOT NULL,
    "QualificacaoResponsavel" text NOT NULL,
    "CapitalSocial" text NOT NULL,
    "PorteEmpresa" text NOT NULL,
    "EnteFederativoResponsavel" text NOT NULL
);

ALTER TABLE public."Empresas" OWNER TO postgres;

CREATE TABLE IF NOT EXISTS public."Estabelecimentos" (
    "CnpjBasico" text NOT NULL,
    "CnpjOrdem" text NOT NULL,
    "CnpjDv" text NOT NULL,
    "IdentificadorMatrizFilial" text NOT NULL,
    "NomeFantasia" text NOT NULL,
    "SituacaoCadastral" text NOT NULL,
    "DataSituacaoCadastral" text NOT NULL,
    "MotivoSituacaoCadastral" text NOT NULL,
    "NomeCidadeExterior" text NOT NULL,
    "Pais" text NOT NULL,
    "DataInicioAtividade" text NOT NULL,
    "CnaeFiscalPrincipal" text NOT NULL,
    "CnaeSecundario" text NOT NULL,
    "TipoLogradouro" text NOT NULL,
    "Logradouro" text NOT NULL,
    "Numero" text NOT NULL,
    "Complemento" text NOT NULL,
    "Bairro" text NOT NULL,
    "Cep" text NOT NULL,
    "Uf" text NOT NULL,
    "Municipio" text NOT NULL,
    "Ddd1" text NOT NULL,
    "Telefone1" text NOT NULL,
    "Ddd2" text NOT NULL,
    "Telefone2" text NOT NULL,
    "DddFax" text NOT NULL,
    "Fax" text NOT NULL,
    "CorreioEletronico" text NOT NULL,
    "SituacaoEspecial" text NOT NULL,
    "DataSituacaoEspecial" text NOT NULL
);

ALTER TABLE public."Estabelecimentos" OWNER TO postgres;

CREATE TABLE IF NOT EXISTS public."Motivos" (
    "Codigo" text NOT NULL,
    "Descricao" text NOT NULL
);


ALTER TABLE public."Motivos" OWNER TO postgres;


CREATE TABLE IF NOT EXISTS public."Municipios" (
    "Codigo" text NOT NULL,
    "Descricao" text NOT NULL
);

ALTER TABLE public."Municipios" OWNER TO postgres;

CREATE TABLE IF NOT EXISTS public."Naturezas" (
    "Codigo" text NOT NULL,
    "Descricao" text NOT NULL
);

ALTER TABLE public."Naturezas" OWNER TO postgres;


CREATE TABLE IF NOT EXISTS public."Paises" (
    "Codigo" text NOT NULL,
    "Descricao" text NOT NULL
);

ALTER TABLE public."Paises" OWNER TO postgres;


CREATE TABLE IF NOT EXISTS public."Qualificacoes" (
    "Codigo" text NOT NULL,
    "Descricao" text NOT NULL
);

ALTER TABLE public."Qualificacoes" OWNER TO postgres;

CREATE TABLE IF NOT EXISTS public."Simples" (
    "CnpjBasico" text NOT NULL,
    "OpcaoSimples" text NOT NULL,
    "DataOpcaoSimples" text NOT NULL,
    "DataExclusaoSimples" text NOT NULL,
    "OpcaoMei" text NOT NULL,
    "DataOpcaoMei" text NOT NULL,
    "DataExclusaoMei" text NOT NULL
);

ALTER TABLE public."Simples" OWNER TO postgres;

CREATE TABLE IF NOT EXISTS public."Socios" (
    "CnpjBasico" text NOT NULL,
    "IdentificadorSocio" text NOT NULL,
    "NomeSocio" text NOT NULL,
    "CnpjCpfSocio" text NOT NULL,
    "QualificacaoSocio" text NOT NULL,
    "DataEntradaSociedade" text NOT NULL,
    "Pais" text NOT NULL,
    "RepresentanteLegal" text NOT NULL,
    "NomeRepresentante" text NOT NULL,
    "QualificacaoRepresentante" text NOT NULL,
    "FaixaEtaria" text NOT NULL
);


ALTER TABLE public."Socios" OWNER TO postgres;