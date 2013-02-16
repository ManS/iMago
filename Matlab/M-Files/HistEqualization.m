function equalizedImage = HistEqualization(img)
[H W L] = size(img);
equalizedImage = uint8(zeros(H,W,L));
for l = 1 : L
    imgHist = imhist(img(:,:,l));
    cumHist = double(256);
    cumHist(1) = imgHist(1);
    for i = 2 : 256
            cumHist(i) = cumHist(i-1)+ imgHist(i);
    end
    cumHist = cumHist *double(255)/double(H*W);
    cumDivideAndMul = uint8(cumHist);
    for i = 1 : H
        for j = 1 : W
            equalizedImage(i,j,l) = cumDivideAndMul(img(i,j,l)+1);
        end
    end
end