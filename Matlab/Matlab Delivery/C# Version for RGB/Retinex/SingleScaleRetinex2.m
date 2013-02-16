
function [r g b]= SingleScaleRetinex2(sigm,Red,Green,Blue)
Img(:,:,1)=Red;
Img(:,:,2)=Green;
Img(:,:,3)=Blue;
N=int32(3.7 * sigm -0.5);
MaskSize=2 * N +1;

GaussianMask = fspecial('gaussian',double(MaskSize),double(sigm));
BlurImg = imfilter(Img,GaussianMask);
 
Retinex=log(((double(Img)+ 1)./(double(BlurImg)+1))); 

%Retinex = Contrast(Retinex,0,255);
r = Retinex(:,:,1);
g=Retinex(:,:,2);
b=Retinex(:,:,3);