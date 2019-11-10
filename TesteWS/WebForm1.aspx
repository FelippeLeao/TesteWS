<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="TesteWS.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            background-color: aquamarine;
        }

        h1 {
            color: black;
            font-family: 'Comic Sans MS';
            font-size: 30px;
            font-weight: bold;
            text-align: center;
        }

        td {
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <h1>Teste de consumo de serviço: ScorpionsAPI </h1>
        <asp:Panel runat="server" ID="pnlResultado">
            <table align="center">
                <tr>
                    <td>Retorno WebService GetFreteByCepFornecedor</td>
                </tr>
                <tr>
                    <td><strong>Valor Frete (R$): </strong></td>
                    <td>
                        <asp:Label runat="server" ID="lblValorFrete"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td><strong>Prazo Frete (R$): </strong></td>
                    <td>
                        <asp:Label runat="server" ID="lblPrazoFrete"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlForm">
            <table align="center">
                <tr>
                    <td>
                        <h4>Dados Produto</h4>
                    </td>
                </tr>
                <tr>
                    <td>Nome: 
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNomeProd" Width="300px"> </asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>Preço (R$): 
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPrecoProd" Width="300px"> </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Peso (Kg): 
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPesoProd" Width="300px"> </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Peso Embalagem De Envio (Kg): 
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPesoEmbProd" Width="300px"> </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Quantidade: 
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtQuantidadeProd" Width="300px"> </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Comprimento (cm): 
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNvlComprimento" Width="300px"> </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Altura (cm): 
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNvlAltura" Width="300px"> </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Largura (cm): 
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNvlLargura" Width="300px"> </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Diametro (cm): 
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNvlDiametro" Width="300px"> </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h4>Dados Frete</h4>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>Para clientes com contrato: Consultar os códigos no seu contrato.</strong>
                        <br />
                        Código do Serviço (Para clientes sem contrato: )
                        <br />
                        <table align="right" style="display:block;">
                            <tr>
                                <td>Código</td>
                                <td>Serviço</td>
                            </tr>
                            <tr>
                                <td>04014</td>
                                <td>SEDEX à vista</td>
                            </tr>
                            <tr>
                                <td>04065</td>
                                <td>SEDEX à vista pagamento na entrega</td>
                            </tr>
                            <tr>
                                <td>04510</td>
                                <td>PAC à vista</td>
                            </tr>
                            <tr>
                                <td>04707</td>
                                <td>PAC à vista pagamento na entrega</td>
                            </tr>
                            <tr>
                                <td>40169</td>
                                <td>SEDEX 12 ( à vista e a faturar)*</td>
                            </tr>
                            <tr>
                                <td>40215</td>
                                <td>SEDEX 10 (à vista e a faturar)*</td>
                            </tr>
                            <tr>
                                <td>40290</td>
                                <td>SEDEX Hoje Varejo*</td>
                            </tr>

                        </table>
                        <br />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNcdServico" Width="300px"> </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <br />
                        Formato da encomenda (incluindo embalagem).
                        <br />
                        Valores possíveis: 1, 2 ou 3
                        <br />
                        1 – Formato caixa/pacote
                        <br />
                        2 – Formato rolo/prisma
                        <br />
                        3 - Envelope  
                        <br />
                        <br />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNcdFormato" Width="300px"> </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Possuí serviço adicional de Mão Própria (Entrega em mãos somente ao próprio destinatário - S ou N): 
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtScdMaoPropria" Width="300px"> </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Valor Declarado (Se não quiser utilizar o serviço, informar zero): 
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNvlValorDeclarado" Width="300px"> </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Possuí serviço adicional de aviso de recebimento (S ou N): 
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtScdAvisoRecebimento" Width="300px"> </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h4>Dados Fornecedor</h4>
                    </td>
                </tr>
                <tr>
                    <td>Nome: 
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNomeForn" Width="300px"> </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>CEP: 
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtCEPForn" Width="300px"> </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Código Administrativo do Contrato da Empresa junto à ECT (Se não houver, deixar vazio): 
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNcdEmpresa" Width="300px"> </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Senha de acesso do Contrato da Empresa com os Correios (Se não houver, deixar vazio):
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtSdsSenha" Width="300px"> </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h4>Dados Cliente</h4>
                    </td>
                </tr>
                <tr>
                    <td>Nome: 
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNomeCli" Width="300px"> </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>CEP: 
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtCEPCli" Width="300px"> </asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:Button runat="server" ID="butObterFrete" Text="Obter Dados Frete" style="float:right;"/>
        </asp:Panel>

    </form>
</body>
</html>
