Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        pnlResultado.Visible = False
    End Sub

    Private Sub butObterFrete_Click(sender As Object, e As EventArgs) Handles butObterFrete.Click
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
        Dim nomeProduto As String = txtNomeProd.Text
        Dim pesoProduto As Double = CType(txtPesoProd.Text.Replace(",", "."), Double)
        Dim pesoEmbalagemProduto As Double = CType(txtPesoEmbProd.Text.Replace(",", "."), Double)
        Dim precoProduto As Double = CType(txtPrecoProd.Text.Replace(",", "."), Double)
        Dim quantProduto As Integer = CInt(txtQuantidadeProd.Text)

        'Dados Produto Frete
        Dim nCdEmpresa As String = txtNcdEmpresa.Text
        Dim sDsSenha As String = txtSdsSenha.Text
        Dim nCdServico As String = txtNcdServico.Text
        Dim sCdAvisoRecebimento As String = txtScdAvisoRecebimento.Text
        Dim sCdMaoPropria As String = txtScdMaoPropria.Text
        Dim nVlComprimento As Decimal = CType(txtNvlComprimento.Text.Replace(",", "."), Double)
        Dim nVlAltura As Decimal = CType(txtNvlAltura.Text.Replace(",", "."), Double)
        Dim nVlLargura As Decimal = CType(txtNvlLargura.Text.Replace(",", "."), Double)
        Dim nVlDiametro As Decimal = CType(txtNvlDiametro.Text.Replace(",", "."), Double)
        Dim nVlValorDeclarado As Decimal = CType(txtNvlValorDeclarado.Text.Replace(",", "."), Double)
        Dim nCdFormato As Integer = CInt(txtNcdFormato.Text)

        'Dados Cliente
        Dim nomeCli As String = txtNomeCli.Text
        Dim cepCli As String = txtCEPCli.Text

        'Dados Fornecedor
        Dim nomeForn As String = txtNomeForn.Text
        Dim cepForn As String = txtCEPForn.Text


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

        Dim listaRequisicao As New List(Of Requisicao)
        With listaRequisicao
            .Add(objRequisicao)
            .Add(objRequisicao)
        End With
        Dim listaRetornos(0) As Retorno

        'Aciona Webservice
        objRetorno = objWsScorpions.GetFreteByCepFornecedor(objRequisicao)
        'listaRetornos = objWsScorpions.GetConjuntoFreteByCepFornecedor(listaRequisicao.ToArray)

        'Exibe Erro retornado pelo Webservice em tela, se houver
        If Not objRetorno Is Nothing AndAlso objRetorno.dadosResposta.msgErro <> "" Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "alertaErroWS", "alert('" & objRetorno.dadosResposta.msgErro & "')", True)
            Exit Sub
        End If

        'Exibe dados retornados pelo Webservice.
        With objRetorno
            pnlResultado.Visible = True
            lblValorFrete.Text = objRetorno.valorFrete
            lblPrazoFrete.Text = objRetorno.prazoFrete & IIf(objRetorno.prazoFrete > 1, " Dias", " Dia")
        End With

    End Sub

    Private Sub ValidaCampos()

    End Sub

End Class




' nCdEmpresa String 
'   Seu código administrativo junto à ECT. O código está' disponível no corpo do contrato firmado com os Correios.

' sDsSenha 
'   Senha para acesso ao serviço, associada ao seu código administrativo. A senha inicial corresponde aos 8 primeiros dígitos do CNPJ informado no contrato.

' nCdServico 
'   Para clientes sem contrato:
'       Códigos Vigentes:
'        Código Serviço
'            04014 SEDEX à vista
'            04065 SEDEX à vista pagamento na entrega
'            04510 PAC à vista
'            04707 PAC à vista pagamento na entrega
'            40169 SEDEX 12 ( à vista e a faturar)*
'            40215 SEDEX 10 (à vista e a faturar)*
'            40290 SEDEX Hoje Varejo*
'    Para clientes com contrato:
'           Consultar os códigos no seu contrato.
' nVlPeso 
'   Peso da encomenda, incluindo sua embalagem. 
'   O peso deve ser informado em quilogramas. 
'   Se o formato for Envelope, o valor máximo permitido será 1 kg.

' nCdFormato 
'   Formato da encomenda (incluindo embalagem).
'   Valores possíveis: 1, 2 ou 3
'   1 – Formato caixa/pacote
'   2 – Formato rolo/prisma
'   3 - Envelope

' nVlComprimento 
'   Comprimento da encomenda (incluindo embalagem), em centímetros.

' nVlAltura 
'   Altura da encomenda (incluindo embalagem), em centímetros. Se o formato for envelope, informar zero (0).

' nVlLargura 
'   Largura da encomenda (incluindo embalagem), em centímetros.

' nVlDiametro 
'   Diâmetro da encomenda (incluindo embalagem), em centímetros.

' sCdMaoPropria 
'   Indica se a encomenda será entregue com o serviço adicional mão própria.
'   Valores possíveis: S ou N (S – Sim, N – Não)

' nVlValorDeclarado 
'   Indica se a encomenda será entregue com o serviço adicional valor declarado. 
'   Neste campo deve ser apresentado o valor declarado desejado, em Reais.
'   Se não optar pelo serviço informar zero.

' sCdAvisoRecebimento 
'   Indica se a encomenda será entregue com o serviço adicional aviso de recebimento.
'   Valores possíveis: S ou N (S – Sim, N – Não)
'   Se não optar pelo serviço informar ‘N’