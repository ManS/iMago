function newImg=LocalStat(WinSize,K0,K1,K2,E,M,Var)
center=floor((size(WinSize)+1)/2);
cx=center(1); 
cy=center(2);
LocalMean =mean2(WinSize);
LocalVar = std2(WinSize);
if(LocalMean <= K0*M) && (LocalVar >= K1 * Var) && (LocalVar <= K2 *Var)
    newImg=E *WinSize(cx,cy);
else
    newImg=WinSize (cx,cy);
end
    