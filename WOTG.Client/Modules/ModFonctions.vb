Module ModFonctions

    ' #################################
    ' ## Module des fonctions du jeu ##
    ' #################################

    ' - Comptacte les valeures X et Y du tiles
    Public Function EncodeXY(ByVal X As Byte, ByVal Y As Byte) As Long
        Return Y * 20 + X
    End Function

    ' - Recupère la valeur X du tiles
    Public Function DecodeX(ByVal code As Long) As Byte
        Return Math.Floor(code - Math.Floor(code / 20) * 20)
    End Function

    ' - Recupère la valeur Y du tiles
    Public Function DecodeY(ByVal code As Long) As Byte
        Return Math.Floor(code / 20)
    End Function
End Module
