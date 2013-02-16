function Final = MSR(OldImage,Sigma)  % MSR = summation i=1 : N {Wi * SSRi} 
N = length(Sigma);
[H W L] = size(OldImage);
Final = double(zeros(H, W, L));
for i=1:N
    Temp = SingleScaleRetinex(double(Sigma(i)),OldImage);
    Final = double((double(Temp).*(double(1/N)))./255+Final);
end