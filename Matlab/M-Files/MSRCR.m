function ResImage = MSRCR(Image,Sigma,Alpha)
[H W L] = size(Image);
ResImage = zeros(H, W , L);
Sum = double(zeros(H, W , 1));
for i = 1 : L
    Sum = double(Image(:,:,i))./255 + Sum;
end
for i = 1 : L
    Temp = double(MSR(Image(:,:,i),Sigma));
    I = double(Image(:,:,i))./255;
    Ci = log(I.*Alpha+0.1)-log(Sum+0.1);
    Test = (Ci.*Temp);
    ResImage(:,:,i) = Test;
end