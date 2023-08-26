CREATE OR REPLACE VIEW public."EstabelecimentoInfoView"
 AS
   SELECT 
	CONCAT(es."CnpjBasico", es."CnpjOrdem", es."CnpjDv") as "Cnpj",
    es."CnpjBasico",
    em."RazaoSocial",
    es."NomeFantasia",
    es."SituacaoCadastral",
    es."CnaeFiscalPrincipal",
    es."CnaeSecundario",
    es."Logradouro",
    es."Numero",
    es."Complemento",
    es."Bairro",
    es."Cep",
    es."Uf",
    mu."Descricao" AS "Municipio",
	CONCAT(es."Ddd1", es."Telefone1") AS "Telefone1",
	CONCAT(es."Ddd2", es."Telefone2") AS "Telefone2",	
    es."CorreioEletronico" AS "Email"
   FROM "Estabelecimentos" es
     LEFT JOIN "Empresas" em ON em."CnpjBasico" = es."CnpjBasico"
     LEFT JOIN "Municipios" mu ON mu."Codigo" = es."Municipio";

ALTER TABLE public."EstabelecimentoInfoView"
    OWNER TO postgres;