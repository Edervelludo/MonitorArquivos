﻿Imports MySql.Data.MySqlClient


Imports MonitorArquivos.AACDRJ.DTO

Namespace AACDRJ.DAL


    Public Class fundeadourosOperacaoPortoDAL

        Private Shared strcon As String
        Shared Sub New()
            strcon = StringBanco()
        End Sub

        Public Function SelecionafundeadourosOperacaoPortoDUV(ByVal DUV As String) As DataTable

            Dim sql = "Select * from aacdrj_fundeadourosOperacaoPorto where numeroDuv = @DUV"
            Dim dt As New DataTable
            Dim con As New MySqlConnection(strcon)
            ' Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()

            'Try

            Dim cmd As New MySqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@DUV", DUV)

                Dim da As New MySqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(dt)

            '   arq_erros.Close()

            'Catch ex As Exception
            '    'MsgBox("Erro: : " & ex.Message, MsgBoxStyle.Critical)
            '    arq_erros.WriteLine(Date.Now)
            '    arq_erros.WriteLine(ex.Message)
            '    arq_erros.WriteLine(ex.StackTrace)
            '    arq_erros.WriteLine(" ")
            '    arq_erros.Close()

            'Finally

            ' con.State = ConnectionState.Open Then
            con.Close()
            'End If

            ' End Try

            Return dt
        End Function

        Public Function insert(ByVal fundop As fundeadourosOperacaoPortoDTO) As Long
            Dim sql As String = "INSERT INTO `aacdrj_fundeadourosOperacaoPorto` ( " &
                                "`numeroDuv` , " &
                                "`fundeadouro` , " &
                                "`boiaAmarracao` " &
                                ") " &
                                "VALUES ( " &
                                "@numeroDuv, @fundeadouro, @boiaAmarracao)"

            Dim cnn As MySqlConnection = New MySqlConnection(strcon)
            ' Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
            Dim id As Integer = 0
            Dim cmd As MySqlCommand = New MySqlCommand(sql, cnn)

            ' Try


            cmd.Parameters.AddWithValue("@numeroDuv", fundop.numeroDuv)
                cmd.Parameters.AddWithValue("@fundeadouro", fundop.fundeadouro)
                cmd.Parameters.AddWithValue("@boiaAmarracao", fundop.boiaAmarracao)



                'Dim sqlrecid = "SELECT LAST_INSERT_ID() INTO @ID;"

                cnn.Open()
                cmd.ExecuteNonQuery()
                id = cmd.LastInsertedId

            '  arq_erros.Close()

            'Catch ex As Exception
            '    arq_erros.WriteLine(Date.Now)
            '    arq_erros.WriteLine(ex.Message)
            '    arq_erros.WriteLine(ex.StackTrace)
            '    arq_erros.WriteLine(cmd.CommandText)
            '    For i As Integer = 0 To cmd.Parameters.Count - 1
            '        arq_erros.WriteLine(cmd.Parameters(i).ParameterName & "----> " & cmd.Parameters(i).Value)
            '    Next
            '    arq_erros.WriteLine(" ")
            '    arq_erros.Close()

            'Finally
            cnn.Close()
            ' End Try
            Return id
        End Function

        'Public Function updade(ByVal fundop As fundeadourosOperacaoPortoDTO) As Integer
        '    Dim sql As String = "UPDATE fundeadourosOperacaoPorto " &
        '                        "SET " &
        '                        "numeroDuv = @numeroDuv , " &
        '                        "fundeadouro = @fundeadouro , " &
        '                        "boiaAmarracao = @boiaAmarracao  " &
        '                        " WHERE (id_fund_op = @id_fund_op)"

        '    Dim cnn As MySqlConnection = New MySqlConnection(strcon)
        '    Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
        '    Dim id As Integer = 0
        '    Dim cmd As MySqlCommand = New MySqlCommand(sql, cnn)

        '    Try



        '        cmd.Parameters.AddWithValue("@numeroDuv", fundop.numeroDuv)
        '        cmd.Parameters.AddWithValue("@fundeadouro", fundop.fundeadouro)
        '        cmd.Parameters.AddWithValue("@boiaAmarracao", fundop.boiaAmarracao)
        '        cmd.Parameters.AddWithValue("@id_fund_op", fundop.id_fund_op)



        '        cnn.Open()
        '        cmd.ExecuteNonQuery()
        '        id = 1

        '        arq_erros.Close()

        '    Catch ex As Exception
        '        arq_erros.WriteLine(Date.Now)
        '        arq_erros.WriteLine(ex.Message)
        '        arq_erros.WriteLine(ex.StackTrace)
        '        arq_erros.WriteLine(cmd.CommandText)
        '        For i As Integer = 0 To cmd.Parameters.Count - 1
        '            arq_erros.WriteLine(cmd.Parameters(i).ParameterName & "----> " & cmd.Parameters(i).Value)
        '        Next
        '        arq_erros.WriteLine(" ")
        '        arq_erros.Close()

        '    Finally
        '        cnn.Close()
        '    End Try

        '    Return id
        'End Function

        Public Function delete(ByVal numeroDuv As String) As Integer
            Dim sql As String = "delete from  aacdrj_fundeadourosOperacaoPorto " &
                               " WHERE (numeroDuv = @numeroDuv)"

            Dim cnn As MySqlConnection = New MySqlConnection(strcon)
            ' Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
            Dim id As Integer = 0
            Dim cmd As MySqlCommand = New MySqlCommand(sql, cnn)

            '  Try



            cmd.Parameters.AddWithValue("@numeroDuv", numeroDuv)

                cnn.Open()
                cmd.ExecuteNonQuery()
                id = 1

            '  arq_erros.Close()

            'Catch ex As Exception
            '    arq_erros.WriteLine(Date.Now)
            '    arq_erros.WriteLine(ex.Message)
            '    arq_erros.WriteLine(ex.StackTrace)
            '    arq_erros.WriteLine(cmd.CommandText)
            '    For i As Integer = 0 To cmd.Parameters.Count - 1
            '        arq_erros.WriteLine(cmd.Parameters(i).ParameterName & "----> " & cmd.Parameters(i).Value)
            '    Next
            '    arq_erros.WriteLine(" ")
            '    arq_erros.Close()

            ' Finally
            cnn.Close()
            'End Try

            Return id
        End Function


    End Class
End Namespace