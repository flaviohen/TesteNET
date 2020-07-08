CREATE TABLE Cliente (
  Cli_ID INT NOT NULL IDENTITY,
  Cli_Nome VARCHAR(250) NULL,
  Cli_UF VARCHAR(3) NULL,
  Cli_Celular VARCHAR(20) NULL,
  PRIMARY KEY(Cli_ID)
);

CREATE TABLE Financiamento (
  Fin_ID INT NOT NULL IDENTITY,
  Cliente_Cli_ID INT NOT NULL,
  Fin_TipoFinanciamento VARCHAR(100) NULL,
  Fin_ValorTotal DECIMAL(10,2) NULL,
  Fin_DataVencimento DATE NULL,
  PRIMARY KEY(Fin_ID)
 ,
  FOREIGN KEY(Cliente_Cli_ID)
    REFERENCES Cliente(Cli_ID)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE INDEX Financiamento_FKIndex1 ON Financiamento(Cliente_Cli_ID);

CREATE TABLE Parcelas (
  Par_NumeroParcela INT NOT NULL IDENTITY,
  Financiamento_Fin_ID INT NOT NULL,
  Par_ValorParcela DECIMAL(10,2) NULL,
  Par_DataVencimento DATE NULL,
  Par_DataPagamento DATE NULL,
  PRIMARY KEY(Par_NumeroParcela)
 ,
  FOREIGN KEY(Financiamento_Fin_ID)
    REFERENCES Financiamento(Fin_ID)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE INDEX Parcelas_FKIndex1 ON Parcelas(Financiamento_Fin_ID);

