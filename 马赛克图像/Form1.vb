Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackgroundImage = GetMosaicBitmap(Me.BackgroundImage, 10)
    End Sub

    Private Function GetMosaicBitmap(ByVal InitialBitmap As Bitmap, CellSize As Integer) As Bitmap
        Dim MosaicBitmap As Bitmap = New Bitmap(InitialBitmap.Width, InitialBitmap.Height)
        Dim CellRectangle As Rectangle = New Rectangle(0, 0, CellSize, CellSize)
        Dim BitmapGraphics As Graphics = Graphics.FromImage(MosaicBitmap)
        Dim TempCell As Bitmap, TempBrush As SolidBrush
        Dim CountInLine As Integer = InitialBitmap.Width \ CellRectangle.Width - 1
        Dim CountInColumn As Integer = InitialBitmap.Height \ CellRectangle.Height - 1
        For IndexY As Integer = 0 To CountInColumn
            CellRectangle.Y = IndexY * CellRectangle.Height
            For IndexX As Integer = 0 To CountInLine
                CellRectangle.X = IndexX * CellRectangle.Width
                TempCell = InitialBitmap.Clone(CellRectangle, Imaging.PixelFormat.Format32bppArgb)
                TempCell = New Bitmap(TempCell, 1, 1)
                TempBrush = New SolidBrush(TempCell.GetPixel(0, 0))

                BitmapGraphics.FillEllipse(TempBrush, CellRectangle) '圆形马赛克
                'BitmapGraphics.FillRectangle(TempBrush, CellRectangle) '方形马赛克
            Next
        Next

        Return MosaicBitmap
    End Function
End Class
