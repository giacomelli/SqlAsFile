--<test-args>
DECLARE @emissorId INT = 2;
--</test-args>

--<cte>
WITH LastMessages(ContatoId, Id, QtdNaoLidas)
AS (
	SELECT ContatoId, MAX(Id), SUM(CASE WHEN Tipo = 1 AND [Status] = 0 THEN 1 ELSE 0 END)
	FROM Mensagem 
	WHERE EmissorId = @emissorId
	GROUP BY ContatoId
)
--</cte>

SELECT 
    M.*, 	
	M.Tipo AS Direcao,
    NULL AS SplitOn1,
    L.QtdNaoLidas 
FROM Mensagem M
	INNER JOIN LastMessages L ON M.Id = L.Id