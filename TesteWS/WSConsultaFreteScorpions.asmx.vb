Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

#Region "Classes"

Public Class Produto
    Private nomeProduto As String
    Public Property nome() As String
        Get
            Return nomeProduto
        End Get
        Set(ByVal value As String)
            nomeProduto = value
        End Set
    End Property

    Private precoProduto As Double
    Public Property preco() As Double
        Get
            Return precoProduto
        End Get
        Set(ByVal value As Double)
            precoProduto = value
        End Set
    End Property

    Private quantidadeProduto As Integer
    Public Property quantidade() As Integer
        Get
            Return quantidadeProduto
        End Get
        Set(ByVal value As Integer)
            quantidadeProduto = value
        End Set
    End Property

    Private pesoProduto As Double
    Public Property peso() As Double
        Get
            Return pesoProduto
        End Get
        Set(ByVal value As Double)
            preco = value
        End Set
    End Property

    Private pesoEmbalagemProduto As Double
    Public Property pesoEmbalagem() As Double
        Get
            Return pesoEmbalagemProduto
        End Get
        Set(ByVal value As Double)
            pesoEmbalagemProduto = value
        End Set
    End Property

    Private nVlComprimentoDadosProdutoFrete As Decimal
    Public Property comprimento() As Decimal
        Get
            Return nVlComprimentoDadosProdutoFrete
        End Get
        Set(ByVal value As Decimal)
            nVlComprimentoDadosProdutoFrete = value
        End Set
    End Property

    Private nVlAlturaDadosProdutoFrete As Decimal
    Public Property altura() As Decimal
        Get
            Return nVlAlturaDadosProdutoFrete
        End Get
        Set(ByVal value As Decimal)
            nVlAlturaDadosProdutoFrete = value
        End Set
    End Property

    Private nVlLarguraDadosProdutoFrete As Decimal
    Public Property largura() As Decimal
        Get
            Return nVlLarguraDadosProdutoFrete
        End Get
        Set(ByVal value As Decimal)
            nVlLarguraDadosProdutoFrete = value
        End Set
    End Property

    Private nVlDiametroDadosProdutoFrete As Decimal
    Public Property diametro() As Decimal
        Get
            Return nVlDiametroDadosProdutoFrete
        End Get
        Set(ByVal value As Decimal)
            nVlDiametroDadosProdutoFrete = value
        End Set
    End Property

    Private dadosProdutoFrete As DadosProdutoFrete
    Public Property dadosFrete() As DadosProdutoFrete
        Get
            Return dadosProdutoFrete
        End Get
        Set(ByVal value As DadosProdutoFrete)
            dadosProdutoFrete = value
        End Set
    End Property

End Class

Public Class Fornecedor
    Private cepFornecedor As String
    Public Property cep() As String
        Get
            Return cepFornecedor
        End Get
        Set(ByVal value As String)
            cepFornecedor = value
        End Set
    End Property

    Private nCdEmpresaDadosProdutoFrete As String
    Public Property nCdEmpresa() As String
        Get
            Return nCdEmpresaDadosProdutoFrete
        End Get
        Set(ByVal value As String)
            nCdEmpresaDadosProdutoFrete = value
        End Set
    End Property

    Private sDsSenhaDadosProdutoFrete As String
    Public Property sDsSenha() As String
        Get
            Return sDsSenhaDadosProdutoFrete
        End Get
        Set(ByVal value As String)
            sDsSenhaDadosProdutoFrete = value
        End Set
    End Property


End Class

Public Class Cliente
    Private cepCliente As String
    Public Property cep() As String
        Get
            Return cepCliente
        End Get
        Set(ByVal value As String)
            cepCliente = value
        End Set
    End Property
End Class

Public Class DadosProdutoFrete
    ' nCdEmpresa 
    '   Seu código administrativo junto à ECT. O código está disponível no corpo do contrato firmado com os Correios.

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
    '   Altura da encomenda (incluindo embalagem), em centímetros. 
    '   Se o formato For envelope, informar zero (0).

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

    'Private nCdEmpresaDadosProdutoFrete As String
    'Public Property nCdEmpresa() As String
    '    Get
    '        Return nCdEmpresaDadosProdutoFrete
    '    End Get
    '    Set(ByVal value As String)
    '        nCdEmpresaDadosProdutoFrete = value
    '    End Set
    'End Property

    'Private sDsSenhaDadosProdutoFrete As String
    'Public Property sDsSenha() As String
    '    Get
    '        Return sDsSenhaDadosProdutoFrete
    '    End Get
    '    Set(ByVal value As String)
    '        sDsSenhaDadosProdutoFrete = value
    '    End Set
    'End Property

    Private nCdServicoDadosProdutoFrete As String
    Public Property nCdServico() As String
        Get
            Return nCdServicoDadosProdutoFrete
        End Get
        Set(ByVal value As String)
            nCdServicoDadosProdutoFrete = value
        End Set
    End Property

    'Private sCepOrigemDadosProdutoFrete As String
    'Public Property sCepOrigem() As String
    '    Get
    '        Return sCepOrigemDadosProdutoFrete
    '    End Get
    '    Set(ByVal value As String)
    '        sCepOrigemDadosProdutoFrete = value
    '    End Set
    'End Property

    'Private sCepDestinoDadosProdutoFrete As String
    'Public Property sCepDestino() As String
    '    Get
    '        Return sCepDestinoDadosProdutoFrete
    '    End Get
    '    Set(ByVal value As String)
    '        sCepDestinoDadosProdutoFrete = value
    '    End Set
    'End Property

    'Private nVlPesoDadosProdutoFrete As String
    'Public Property nVlPeso() As String
    '    Get
    '        Return nVlPesoDadosProdutoFrete
    '    End Get
    '    Set(ByVal value As String)
    '        nVlPesoDadosProdutoFrete = value
    '    End Set
    'End Property

    Private sCdAvisoRecebimentoDadosProdutoFrete As String
    Public Property sCdAvisoRecebimento() As String
        Get
            Return sCdAvisoRecebimentoDadosProdutoFrete
        End Get
        Set(ByVal value As String)
            sCdAvisoRecebimentoDadosProdutoFrete = value
        End Set
    End Property

    Private sCdMaoPropriaDadosProdutoFrete As String
    Public Property sCdMaoPropria() As String
        Get
            Return sCdMaoPropriaDadosProdutoFrete
        End Get
        Set(ByVal value As String)
            sCdMaoPropriaDadosProdutoFrete = value
        End Set
    End Property

    'Private nVlComprimentoDadosProdutoFrete As Decimal
    'Public Property nVlComprimento() As Decimal
    '    Get
    '        Return nVlComprimentoDadosProdutoFrete
    '    End Get
    '    Set(ByVal value As Decimal)
    '        nVlComprimentoDadosProdutoFrete = value
    '    End Set
    'End Property

    'Private nVlAlturaDadosProdutoFrete As Decimal
    'Public Property nVlAltura() As Decimal
    '    Get
    '        Return nVlAlturaDadosProdutoFrete
    '    End Get
    '    Set(ByVal value As Decimal)
    '        nVlAlturaDadosProdutoFrete = value
    '    End Set
    'End Property

    'Private nVlLarguraDadosProdutoFrete As Decimal
    'Public Property nVlLargura() As Decimal
    '    Get
    '        Return nVlLarguraDadosProdutoFrete
    '    End Get
    '    Set(ByVal value As Decimal)
    '        nVlLarguraDadosProdutoFrete = value
    '    End Set
    'End Property

    'Private nVlDiametroDadosProdutoFrete As Decimal
    'Public Property nVlDiametro() As Decimal
    '    Get
    '        Return nVlDiametroDadosProdutoFrete
    '    End Get
    '    Set(ByVal value As Decimal)
    '        nVlDiametroDadosProdutoFrete = value
    '    End Set
    'End Property

    Private nVlValorDeclaradoDadosProdutoFrete As Decimal
    Public Property nVlValorDeclarado() As Decimal
        Get
            Return nVlValorDeclaradoDadosProdutoFrete
        End Get
        Set(ByVal value As Decimal)
            nVlValorDeclaradoDadosProdutoFrete = value
        End Set
    End Property

    Private nCdFormatoDadosProdutoFrete As Integer
    Public Property nCdFormato() As Integer
        Get
            Return nCdFormatoDadosProdutoFrete
        End Get
        Set(ByVal value As Integer)
            nCdFormatoDadosProdutoFrete = value
        End Set
    End Property

End Class

Public Class StatusResposta

    Private codStatusResposta As Integer
    Public Property codStatus() As Integer
        Get
            Return codStatusResposta
        End Get
        Set(ByVal value As Integer)
            codStatusResposta = value
        End Set
    End Property

    Private codErroResposta As Integer
    Public Property codErro() As Integer
        Get
            Return codErroResposta
        End Get
        Set(ByVal value As Integer)
            codErroResposta = value
        End Set
    End Property

    Private msgErroResposta As String
    Public Property msgErro() As String
        Get
            Return msgErroResposta
        End Get
        Set(ByVal value As String)
            msgErroResposta = value
        End Set
    End Property

End Class

Public Class Requisicao
    Private objProduto As Produto
    Public Property dadosProduto() As Produto
        Get
            Return objProduto
        End Get
        Set(ByVal value As Produto)
            objProduto = value
        End Set
    End Property

    Private objDadosProdutoFrete As DadosProdutoFrete
    Public Property dadosProdutoFrete() As DadosProdutoFrete
        Get
            Return objDadosProdutoFrete
        End Get
        Set(ByVal value As DadosProdutoFrete)
            objDadosProdutoFrete = value
        End Set
    End Property

    Private objDadosFornecedor As Fornecedor
    Public Property dadosFornecedor() As Fornecedor
        Get
            Return objDadosFornecedor
        End Get
        Set(ByVal value As Fornecedor)
            objDadosFornecedor = value
        End Set
    End Property

    Private objDadosCliente As Cliente
    Public Property dadosCliente() As Cliente
        Get
            Return objDadosCliente
        End Get
        Set(ByVal value As Cliente)
            objDadosCliente = value
        End Set
    End Property

End Class

Public Class Retorno
    Private valorFreteRetorno As Double
    Public Property valorFrete() As Double
        Get
            Return valorFreteRetorno
        End Get
        Set(ByVal value As Double)
            valorFreteRetorno = value
        End Set
    End Property

    Private prazoFreteRetorno As String
    Public Property prazoFrete() As String
        Get
            Return prazoFreteRetorno
        End Get
        Set(ByVal value As String)
            prazoFreteRetorno = value
        End Set
    End Property

    Private objDadosResposta As StatusResposta
    Public Property dadosResposta() As StatusResposta
        Get
            Return objDadosResposta
        End Get
        Set(ByVal value As StatusResposta)
            objDadosResposta = value
        End Set
    End Property
End Class

#End Region

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WSConsultaFreteScorpions
    Inherits System.Web.Services.WebService

    <WebMethod(MessageName:="teste 1")>
    Public Function GetFreteByCepFornecedor(ByRef objRequisicao As Requisicao) As Retorno
        Dim objRetorno As New Retorno
        Dim objResposta As New StatusResposta
        objRetorno.dadosResposta = objResposta
        Dim objWsCorreiosGetEndByCep = New WSCorreiosGetEnderecoByCep.AtendeClienteClient
        Dim objWsCorreiosPrecoPrazo = New WSCorreios.CalcPrecoPrazoWSSoapClient
        'ValidaCampos(objRequisicao)
        With objRequisicao
            Try
                Dim pesoTotal As Double = (.dadosProduto.peso + .dadosProduto.pesoEmbalagem) * .dadosProduto.quantidade
                If .dadosProduto.dadosFrete.nCdFormato = 3 Then 'Se formato for envelope, Correios exige que a altura seja zero.
                    .dadosProduto.altura = 0
                End If

                Dim objEnderecoCompletoFornecedor As WSCorreiosGetEnderecoByCep.enderecoERP = objWsCorreiosGetEndByCep.consultaCEP(.dadosFornecedor.cep)
                Dim objEnderecoCompletoCliente As WSCorreiosGetEnderecoByCep.enderecoERP = objWsCorreiosGetEndByCep.consultaCEP(.dadosCliente.cep)
                If (Not objEnderecoCompletoFornecedor Is Nothing) AndAlso (Not objEnderecoCompletoCliente Is Nothing) Then
                    Dim objPrecoPrazo As WSCorreios.cResultado = objWsCorreiosPrecoPrazo.CalcPrecoPrazo(
                    .dadosFornecedor.nCdEmpresa,
                    .dadosFornecedor.sDsSenha,
                    .dadosProdutoFrete.nCdServico,
                    .dadosFornecedor.cep,
                    .dadosCliente.cep,
                    pesoTotal,
                    .dadosProdutoFrete.nCdFormato,
                    .dadosProduto.comprimento,
                    .dadosProduto.altura,
                    .dadosProduto.largura,
                    .dadosProduto.diametro,
                    .dadosProdutoFrete.sCdMaoPropria,
                    .dadosProdutoFrete.nVlValorDeclarado,
                    .dadosProdutoFrete.sCdAvisoRecebimento
                    )
                    If objPrecoPrazo.Servicos(0).MsgErro <> "" Then
                        SetDadosResposta(2, -888, objPrecoPrazo.Servicos(0).MsgErro, objRetorno.dadosResposta)
                    Else
                        With objRetorno
                            .prazoFrete = objPrecoPrazo.Servicos(0).PrazoEntrega
                            .valorFrete = CType(objPrecoPrazo.Servicos(0).Valor.Replace(",", "."), Double)
                            SetDadosResposta(-1, 500, "", .dadosResposta)
                        End With
                    End If
                Else
                    SetDadosResposta(1, -777, "CEP inexistente ou inválido.", objRetorno.dadosResposta)
                End If
                Return objRetorno
            Catch ex As Exception
                SetDadosResposta(1, -777, ex.Message, objRetorno.dadosResposta)
                Return objRetorno
            End Try
        End With
    End Function

    <WebMethod(MessageName:="teste 2")>
    Public Function GetConjuntoFreteByCepFornecedor(ByRef objRequisicao() As Requisicao) As Retorno()
        Dim listaRetorno As New List(Of Retorno)
        For a As Integer = 0 To objRequisicao.Length - 1

            Dim objRetorno As New Retorno
            Dim objResposta As New StatusResposta
            objRetorno.dadosResposta = objResposta
            Dim objWsCorreiosGetEndByCep = New WSCorreiosGetEnderecoByCep.AtendeClienteClient
            Dim objWsCorreiosPrecoPrazo = New WSCorreios.CalcPrecoPrazoWSSoapClient
            'ValidaCampos(objRequisicao)
            With objRequisicao(a)
                Try
                    Dim pesoTotal As Double = (.dadosProduto.peso + .dadosProduto.pesoEmbalagem) * .dadosProduto.quantidade
                    If .dadosProduto.dadosFrete.nCdFormato = 3 Then 'Se formato for envelope, Correios exige que a altura seja zero.
                        .dadosProduto.altura = 0
                    End If

                    Dim objEnderecoCompletoFornecedor As WSCorreiosGetEnderecoByCep.enderecoERP = objWsCorreiosGetEndByCep.consultaCEP(.dadosFornecedor.cep)
                    Dim objEnderecoCompletoCliente As WSCorreiosGetEnderecoByCep.enderecoERP = objWsCorreiosGetEndByCep.consultaCEP(.dadosCliente.cep)
                    If (Not objEnderecoCompletoFornecedor Is Nothing) AndAlso (Not objEnderecoCompletoCliente Is Nothing) Then
                        Dim objPrecoPrazo As WSCorreios.cResultado = objWsCorreiosPrecoPrazo.CalcPrecoPrazo(
                        .dadosFornecedor.nCdEmpresa,
                        .dadosFornecedor.sDsSenha,
                        .dadosProdutoFrete.nCdServico,
                        .dadosFornecedor.cep,
                        .dadosCliente.cep,
                        pesoTotal,
                        .dadosProdutoFrete.nCdFormato,
                        .dadosProduto.comprimento,
                        .dadosProduto.altura,
                        .dadosProduto.largura,
                        .dadosProduto.diametro,
                        .dadosProdutoFrete.sCdMaoPropria,
                        .dadosProdutoFrete.nVlValorDeclarado,
                        .dadosProdutoFrete.sCdAvisoRecebimento
                        )
                        If objPrecoPrazo.Servicos(0).MsgErro <> "" Then
                            SetDadosResposta(2, -888, objPrecoPrazo.Servicos(0).MsgErro, objRetorno.dadosResposta)
                        Else
                            With objRetorno
                                .prazoFrete = objPrecoPrazo.Servicos(0).PrazoEntrega
                                .valorFrete = CType(objPrecoPrazo.Servicos(0).Valor.Replace(",", "."), Double)
                                SetDadosResposta(-1, 500, "", .dadosResposta)
                            End With
                        End If
                    Else
                        SetDadosResposta(1, -777, "CEP inexistente ou inválido.", objRetorno.dadosResposta)
                    End If
                    listaRetorno.Add(objRetorno)
                Catch ex As Exception
                    SetDadosResposta(1, -777, ex.Message, objRetorno.dadosResposta)
                    listaRetorno.Add(objRetorno)
                End Try
            End With
        Next a
        Return listaRetorno.ToArray
    End Function

    Private Sub SetDadosResposta(ByVal codErro As Integer, ByVal codStatus As Integer, ByVal msgErro As String, ByRef dadosResposta As StatusResposta)
        With dadosResposta
            .codErro = codErro
            .codStatus = codStatus
            .msgErro = msgErro
        End With
    End Sub

End Class