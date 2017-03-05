' [ Centered Messagebox ]
'
' Examples :
'
' Using New MessageBox_Centered(Me)
'     MessageBox.Show("Test Text", "Test Title", MessageBoxButtons.OK)
' End Using

#Region " Centered MessageBox Class"

Imports System.Runtime.InteropServices
Imports System.Text

Class MessageBox_Centered
    Implements IDisposable

    ' P/Invoke
    Public Class NativeMethods

        Delegate Function EnumThreadWndProc(hWnd As IntPtr, lp As IntPtr) As Boolean

        <DllImport("user32.dll")> _
        Shared Function EnumThreadWindows(tid As Integer, callback As EnumThreadWndProc, lp As IntPtr) As Boolean
        End Function

        <DllImport("kernel32.dll")> _
        Shared Function GetCurrentThreadId() As Integer
        End Function

        <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)> _
        Shared Function GetClassName(hWnd As IntPtr, buffer As StringBuilder, buflen As Integer) As Integer
        End Function

        <DllImport("user32.dll")> _
        Shared Function GetWindowRect(hWnd As IntPtr, ByRef rc As RECT) As Boolean
        End Function

        <DllImport("user32.dll")> _
        Shared Function MoveWindow(hWnd As IntPtr, x As Integer, y As Integer, w As Integer, h As Integer, repaint As Boolean) As Boolean
        End Function

        Structure RECT
            Public Left As Integer
            Public Top As Integer
            Public Right As Integer
            Public Bottom As Integer
        End Structure

    End Class

    Private mTries As Integer = 0
    Private mOwner As Form

    Public Sub New(owner As Form)
        mOwner = owner
        owner.BeginInvoke(New MethodInvoker(AddressOf findDialog))
    End Sub

    Private Sub findDialog()

        ' Enumerate windows to find the message box
        If mTries < 0 Then Return

        Dim callback As New NativeMethods.EnumThreadWndProc(AddressOf checkWindow)
        If NativeMethods.EnumThreadWindows(NativeMethods.GetCurrentThreadId(), callback, IntPtr.Zero) Then
            If System.Threading.Interlocked.Increment(mTries) < 10 Then
                mOwner.BeginInvoke(New MethodInvoker(AddressOf findDialog))
            End If
        End If

    End Sub

    Private Function checkWindow(hWnd As IntPtr, lp As IntPtr) As Boolean

        ' Checks if <hWnd> is a dialog
        Dim sb As New StringBuilder(260)
        NativeMethods.GetClassName(hWnd, sb, sb.Capacity)
        If sb.ToString() <> "#32770" Then Return True

        ' Got it
        Dim frmRect As New Rectangle(mOwner.Location, mOwner.Size)
        Dim dlgRect As NativeMethods.RECT
        NativeMethods.GetWindowRect(hWnd, dlgRect)
        NativeMethods.MoveWindow(hWnd, frmRect.Left + (frmRect.Width - dlgRect.Right + dlgRect.Left) \ 2, frmRect.Top + (frmRect.Height - dlgRect.Bottom + dlgRect.Top) \ 2, dlgRect.Right - dlgRect.Left, dlgRect.Bottom - dlgRect.Top, True)
        Return False

    End Function

    Public Sub Dispose() Implements IDisposable.Dispose
        mTries = -1
    End Sub

End Class

#End Region