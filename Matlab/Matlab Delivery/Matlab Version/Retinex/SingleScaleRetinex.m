
function newImg= SingleScaleRetinex(sigm,Img)
N=int32(3.7 * sigm -0.5);
MaskSize=2 * N +1;

GaussianMask = fspecial('gaussian',double(MaskSize),double(sigm));
BlurImg = imfilter(Img,GaussianMask);
 
Retinex=log(((double(Img)+ 1)./(double(BlurImg)+1))); 

Retinex = Contrast(Retinex,0,255);
newImg = Retinex;

%Retinex(:,:,1) = HistEqualization(Retinex(:,:,1));
%Retinex(:,:,2) = HistEqualization(Retinex(:,:,2));
%Retinex(:,:,3) = HistEqualization(Retinex(:,:,3));
% figure, imshow(uint16(Retinex));
% %Normalization
% NewMax = 255;
% NewMin = 0;
% 
% MaxR = int16(max(max(Retinex(:,:,1))));
% MaxG = max(max(Retinex(:,:,2)));
% MaxB = max(max(Retinex(:,:,3)));
% 
% MinR = min(min(Retinex(:,:,1)));
% MinG = min(min(Retinex(:,:,2)));
% MinB = min(min(Retinex(:,:,3)));
% 
% Retinex(:,:,1) =int16(((double(Retinex(:,:,1)) - double(MinR))*double(NewMax-NewMin))./double((MaxR - MinR))+double(NewMin));
% figure, imshow(uint8(Retinex));
% Retinex(:,:,2) = int16(((double(Retinex(:,:,2)) - double(MinG))*double(NewMax-NewMin))./double((MaxG - MinG))+double(NewMin));
% figure, imshow(uint8(Retinex));
% 
% Retinex(:,:,3) = int16(((double(Retinex(:,:,3)) - double(MinB))*double(NewMax-NewMin))./double((MaxB - MinB))+double(NewMin));
% imshow(uint16(Retinex));
% newImg = uint8(Retinex);