image=imread('LocalStats.bmp');
Mat=double(image);
M=mean2(Mat);
Var=std2 (Mat);
winSize=[5 5];
K0=1.0;
K1=0.4;
K2=1.4;
E=4;
newImage=nlfilter(Mat,winSize,@LocalStat,K0,K1,K2,E,M,Var);
EnhImage=im2uint8(mat2gray(newImage));
imshow (EnhImage);
