function [R,G,B]=LocalHE2(WinSize,Red,Green,Blue)
Img(:,:,1)=Red;
Img(:,:,2)=Green;
Img(:,:,3)=Blue;
[H W L] = size(Img);
newImg = uint8(ones(H,W,L));
x = double(int32(WinSize/2)-1);
paddedImage = padarray(Img,[x,x],'replicate','both');
[H W L] = size(paddedImage);
X = floor(WinSize/2)+1;
Q = X-1;
     for w = X :(W-Q)
        for h = X : (H-Q)
          subImage = paddedImage(h-Q:h+Q,w-Q:w+Q,:);
          his = HistEqualization(subImage);
          val = his(X,X,:);
          newImg(h-Q,w-Q,:) = val;
        end
     end
     
     R=newImg(:,:,1);
     G=newImg(:,:,2);
     B=newImg(:,:,3);
end