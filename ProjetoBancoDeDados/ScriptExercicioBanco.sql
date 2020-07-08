
declare @IDFinanciamento int 
declare @totalParcelaPorFinanciamento int
declare @totalParcelasPagaPorFinanciamento int

set @IDFinanciamento = 1
set @totalParcelaPorFinanciamento = (select Count(p.Par_NumeroParcela) from Parcelas p where p.Financiamento_Fin_ID = @IDFinanciamento)
set @totalParcelasPagaPorFinanciamento = (select Count(p.Par_NumeroParcela) from Parcelas p where p.Financiamento_Fin_ID = @IDFinanciamento and p.Par_DataPagamento is not null)

select c.*, f.* from Cliente c
inner join Financiamento f on f.Cliente_Cli_ID = c.Cli_ID
where c.Cli_UF = 'SP' and 
	  f.Fin_ID = @IDFinanciamento and 
	  ((@totalParcelasPagaPorFinanciamento * 100)/@totalParcelaPorFinanciamento) > 60

---------------------------------------------------------------------------------------------------------------------------------
declare @diasDeAtraso int
set @diasDeAtraso = 5

select top(4) c.*, p.* from Cliente c
inner join Financiamento f on f.Cliente_Cli_ID = c.Cli_ID
inner join Parcelas p on p.Financiamento_Fin_ID = f.Fin_ID
where p.Par_DataPagamento is null and (datediff(day,p.Par_DataVencimento,GETDATE())) > @diasDeAtraso

--------------------------------------------------------------------------------------------------------------------------------

declare @valorFinanciamento decimal(10,2)
declare @atraso int
set @atraso = 10
set @valorFinanciamento = 10000

select distinct c.*, p.* from Cliente c
inner join Financiamento f on f.Cliente_Cli_ID = c.Cli_ID
inner join Parcelas p on p.Financiamento_Fin_ID = f.Fin_ID
where f.Fin_ValorTotal > @valorFinanciamento and (DATEDIFF(DAY,p.Par_DataVencimento,p.Par_DataPagamento) > @atraso)



 