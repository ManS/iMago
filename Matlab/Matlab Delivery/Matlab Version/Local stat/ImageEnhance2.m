function EnhImage=ImageEnhance2(image,E,K0,K1,K2,winSize)

%image=rgb2gray(i);
Mat=double(image);
M=mean2(image);
Var=std2 (image);

newImage=nlfilter(Mat,[winSize winSize],@LocalStat,K0,K1,K2,E,M,Var);
EnhImage=im2uint8(mat2gray(newImage));

