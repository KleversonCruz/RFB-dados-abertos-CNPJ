CREATE INDEX idx_empresas_cnpjbasico ON public."Empresas" USING btree ("CnpjBasico");
CREATE INDEX idx_estabelecimentos_cnpjbasico ON public."Estabelecimentos" USING btree ("CnpjBasico");
CREATE INDEX idx_simples_cnpjbasico ON public."Simples" USING btree ("CnpjBasico");
CREATE INDEX idx_socios_cnpjbasico ON public."Socios" USING btree ("CnpjBasico");
CREATE INDEX idx_municipios_codigo ON public."Municipios" USING btree ("Codigo");
