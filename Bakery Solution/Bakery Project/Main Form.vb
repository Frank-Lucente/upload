' Name:         Bakery Project
' Purpose:      Calculates the total number of
'               items sold and the total sales
' Programmer:   <Jordan Pritt> on <2/15/2017>

Option Explicit On
Option Infer Off
Option Strict On

Public Class frmMain

    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click
        'constant variable declaration
        Const decITEM_PRICE As Decimal = 0.5D
        Const decTAX_RATE As Decimal = 0.02D
        Const strPROMPT As String = "Salesclerk's name:"
        Const strTITLE As String = "Name Entry"

        'variable declaration
        Dim intDonuts As Integer
        Dim intMuffins As Integer
        Dim intTotalItems As Integer
        Dim decSubTotal As Decimal
        Dim decSalesTax As Decimal
        Dim decTotalSales As Decimal

        'static variable
        Static strClerk As String

        'assign name to variable
        strClerk = InputBox(strPROMPT, strTITLE, strClerk)

        ' calculate number of items sold and total sales
        Integer.TryParse(txtDonuts.Text, intDonuts)
        Integer.TryParse(txtMuffins.Text, intMuffins)
        intTotalItems = intDonuts + intMuffins

        'calculate the sub total
        decSubTotal = intTotalItems * decITEM_PRICE

        'calculate tax
        decSalesTax = decSubTotal * decTAX_RATE

        'calulcate the total sale
        decTotalSales = decSubTotal + decSalesTax

        'display total amounts
        lblTotalItems.Text = Convert.ToString(intTotalItems)
        lblTotalSales.Text = decTotalSales.ToString("C2")

        'display tax and sales clerk's name
        lblMsg.Text = "The sales tax was " &
            decSalesTax.ToString("C2") & ". " &
            ControlChars.NewLine & strClerk

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ' prepare screen for the next sale

        txtDonuts.Text = String.Empty
        txtMuffins.Text = String.Empty
        lblTotalItems.Text = String.Empty
        lblTotalSales.Text = String.Empty
        lblMsg.Text = String.Empty
        ' send the focus to the Doughnuts box
        txtDonuts.Focus()

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        ' print the sales receipt

        btnCalc.Visible = False
        btnClear.Visible = False
        btnExit.Visible = False
        btnPrint.Visible = False
        PrintForm1.Print()
        btnCalc.Visible = True
        btnClear.Visible = True
        btnExit.Visible = True
        btnPrint.Visible = True

    End Sub

    Private Sub ClearLabels(sender As Object, e As EventArgs) _
        Handles txtDonuts.TextChanged, txtMuffins.TextChanged
        'clears total items, and total sales message
        lblTotalItems.Text = String.Empty
        lblTotalSales.Text = String.Empty
        lblMsg.Text = String.Empty
    End Sub

End Class
