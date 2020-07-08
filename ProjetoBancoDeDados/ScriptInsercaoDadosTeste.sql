-- Inserindo dados tabela de Cliente
INSERT INTO Cliente(Cli_Nome,Cli_UF,Cli_Celular)
VALUES('Flavio Henrique','SP','11945254466')

INSERT INTO Cliente(Cli_Nome,Cli_UF,Cli_Celular)
VALUES('Luiz Carlos','SP','11955224466')

INSERT INTO Cliente(Cli_Nome,Cli_UF,Cli_Celular)
VALUES('Felipe Agusto','SP','11974548511')

INSERT INTO Cliente(Cli_Nome,Cli_UF,Cli_Celular)
VALUES('Daniele Ferreira','SP','11985449944')

--Inserindo Financiamento
INSERT INTO Financiamento(Cliente_Cli_ID,Fin_TipoFinanciamento,Fin_ValorTotal,Fin_DataVencimento)
VALUES (1,'tipo1',15000,'2020-07-30')

INSERT INTO Financiamento(Cliente_Cli_ID,Fin_TipoFinanciamento,Fin_ValorTotal,Fin_DataVencimento)
VALUES (2,'tipo2',50000,'2020-07-15')

INSERT INTO Financiamento(Cliente_Cli_ID,Fin_TipoFinanciamento,Fin_ValorTotal,Fin_DataVencimento)
VALUES (3,'tipo3',60000,'2020-07-20')

INSERT INTO Financiamento(Cliente_Cli_ID,Fin_TipoFinanciamento,Fin_ValorTotal,Fin_DataVencimento)
VALUES (4,'tipo4',51540,'2020-07-05')

--Inserindo parcelas do Financiamento
INSERT INTO Parcelas(Financiamento_Fin_ID, Par_ValorParcela,Par_DataVencimento,Par_DataPagamento)
VALUES (1,500,'2020-07-10', NULL)
INSERT INTO Parcelas(Financiamento_Fin_ID, Par_ValorParcela,Par_DataVencimento,Par_DataPagamento)
VALUES (1,500,'2020-07-08', '2020-07-07')

INSERT INTO Parcelas(Financiamento_Fin_ID, Par_ValorParcela,Par_DataVencimento,Par_DataPagamento)
VALUES (2,350,'2020-07-05', NULL)
INSERT INTO Parcelas(Financiamento_Fin_ID, Par_ValorParcela,Par_DataVencimento,Par_DataPagamento)
VALUES (2,350,'2020-07-11', NULL)

INSERT INTO Parcelas(Financiamento_Fin_ID, Par_ValorParcela,Par_DataVencimento,Par_DataPagamento)
VALUES (3,200,'2020-07-05', '2020-07-05')
INSERT INTO Parcelas(Financiamento_Fin_ID, Par_ValorParcela,Par_DataVencimento,Par_DataPagamento)
VALUES (3,200,'2020-07-01', NULL)

INSERT INTO Parcelas(Financiamento_Fin_ID, Par_ValorParcela,Par_DataVencimento,Par_DataPagamento)
VALUES (4,400,'2020-07-10', '2020-07-09')
INSERT INTO Parcelas(Financiamento_Fin_ID, Par_ValorParcela,Par_DataVencimento,Par_DataPagamento)
VALUES (4,400,'2020-07-20', NULL)