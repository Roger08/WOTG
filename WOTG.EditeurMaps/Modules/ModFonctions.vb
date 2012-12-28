Module ModFonctions

    ' #################################
    ' ## Module des fonctions du jeu ##
    ' #################################

    Public Function KeyGen(ByVal Strlong As Integer) As String
        Randomize()
        Dim tbl() As String 'le tableau des caracteres
        Dim strx As String = "K" 'la chaine qu'on va créer
        tbl = Split("a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,K,R,S,T,U,V,W,X,Y,Z,0,1,2,3,4,5,6,7,8,9", ",")
        For I = 1 To Strlong
            strx = strx & tbl(Int((UBound(tbl) + 1) * Rnd()))
        Next I
        Return strx
    End Function

End Module
