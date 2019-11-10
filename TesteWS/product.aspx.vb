Public Class product
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Sub lnkCalcFrete_Click(sender As Object, e As EventArgs) Handles lnkCalcFrete.Click
        'Dim objWsGetEndByCep = New WSCorreiosGetEnderecoByCep.AtendeClienteClient
        'Dim resultadoEndByCep As WSCorreiosGetEnderecoByCep.enderecoERP = objWsGetEndByCep.consultaCEP(cep)
        'Dim objWs = New WSCorreios.CalcPrecoPrazoWSSoapClient
        Dim objWsScorpions As New WSConsultaFreteScorpions
        Dim objRequisicao As New Requisicao
        Dim objRetorno As New Retorno
        Dim objProduto As New Produto
        Dim objDadosFrete As New DadosProdutoFrete
        Dim objFornecedor As New Fornecedor
        Dim objCliente As New Cliente

        'Dados Produto
        Dim nomeProduto As String = "Miniatura de LEGO do Homem Aranha (Sam Raimi)"
        Dim pesoProduto As Double = 0.025
        Dim pesoEmbalagemProduto As Double = 0.01
        Dim precoProduto As Double = "0.97"
        Dim quantProduto As Integer = CInt(quantity_input.Text)


        'Dados Produto Frete
        Dim nCdEmpresa As String = ""
        Dim sDsSenha As String = ""
        Dim nCdServico As String = "04014"
        Dim sCdAvisoRecebimento As String = "S"
        Dim sCdMaoPropria As String = "S"
        Dim nVlComprimento As Decimal = 50
        Dim nVlAltura As Decimal = 50
        Dim nVlLargura As Decimal = 50
        Dim nVlDiametro As Decimal = 50
        Dim nVlValorDeclarado As Decimal = 20
        Dim nCdFormato As Integer = 3

        'Dados Cliente
        Dim nomeCli As String = "Felippe"
        Dim cepCli As String = cep.Text


        'Dados Fornecedor
        Dim nomeForn As String = "Loja E-Commerce Barato"
        Dim cepForn As String = "01508040"


        'Dim resultado As WSCorreios.cResultado = objWs.CalcPrecoPrazo(nCdEmpresa, sDsSenha, nCdServico, sCepOrigem, sCepDestino, nVlPeso, nCdFormato, nVlComprimento, nVlAltura, nVlLargura, nVlDiametro, sCdMaoPropria, nVlValorDeclarado, sCdAvisoRecebimento)
        'If Not resultado Is Nothing AndAlso resultado.Servicos(0).MsgErro <> "" Then
        '    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "alertaErroWSPrecoPrazo", "alert('" & resultado.Servicos(0).MsgErro & "')", True)
        'End If

        'Cria Objetos para requisição do Webservice
        Try
            With objDadosFrete
                .nCdServico = nCdServico
                .sCdAvisoRecebimento = sCdAvisoRecebimento
                .sCdMaoPropria = sCdMaoPropria
                .nVlValorDeclarado = nVlValorDeclarado
                .nCdFormato = nCdFormato
            End With

            With objProduto
                .nome = nomeProduto
                .peso = pesoProduto
                .pesoEmbalagem = pesoEmbalagemProduto
                .preco = precoProduto
                .quantidade = quantProduto
                .comprimento = nVlComprimento
                .altura = nVlAltura
                .largura = nVlLargura
                .diametro = nVlDiametro
                .dadosFrete = objDadosFrete
            End With

            With objCliente
                .cep = cepCli
            End With

            With objFornecedor
                .cep = cepForn
                .nCdEmpresa = nCdEmpresa
                .sDsSenha = sDsSenha
            End With
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "alertaErroWS", "alert('Erro inesperado de atribuição dos dados inseridos. \n\n " & ex.Message & "')", True)
            Exit Sub
        End Try

        With objRequisicao
            .dadosProduto = objProduto
            .dadosProdutoFrete = objDadosFrete
            .dadosFornecedor = objFornecedor
            .dadosCliente = objCliente
        End With

        'Aciona Webservice
        objRetorno = objWsScorpions.GetFreteByCepFornecedor(objRequisicao)

        'Exibe Erro retornado pelo Webservice em tela, se houver
        If Not objRetorno Is Nothing AndAlso objRetorno.dadosResposta.msgErro <> "" Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "alertaErroWS", "alert('" & objRetorno.dadosResposta.msgErro & "')", True)
            Exit Sub
        End If

        'Exibe dados retornados pelo Webservice.
        With objRetorno
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "alertOk", "alert('Frete simulado via webservice Scorpions. \n\n Valor Frete: R$" & objRetorno.valorFrete & "\n\n Prazo frete (Dias): " & objRetorno.prazoFrete.ToString & "')", True)
            'Throw New Exception("Frete simulado via webservice Scorpions. \n\n Valor Frete: R$" & objRetorno.valorFrete.ToString & " \ n \ n Prazo frete (Dias): " & objRetorno.prazoFrete.ToString & ")")
        End With
    End Sub
End Class