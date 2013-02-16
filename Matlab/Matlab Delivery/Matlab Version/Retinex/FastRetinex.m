function newImg= FastRetinex(sigm,Img)
N=int32(3.7 * sigm -0.5);
MaskSize=double(2 * N +1);

filt_h= fspecial('gaussian',[1,MaskSize],sigm);
y_row=convn(Img,filt_h,'same');
filt_v= fspecial('gaussian',[MaskSize,1],sigm);
y_filt=convn(y_row,filt_v,'same');

Retinex=log(((double(Img)+ 1)./(double(y_filt)+ 1)));
Retinex = Contrast(Retinex,0,255);
newImg=Retinex;