function New = histslicing(Old,OldMin,OldMax,NewVal)
[W H L] = size(Old);
New = uint8(zeros(W,H,L));
for i=1:L
    TmpBuf = double(Old(:,:,i));
    for j=1:W
       for k=1:H
           NewValu = TmpBuf(j,k);
           if ((TmpBuf(j,k)>= OldMin) && (TmpBuf(j,k)<= OldMax))
            NewValu =NewVal;
           end
           if (NewValu<0)
            NewValu = 0;
           end
           
           if (NewValu>255)
            NewValu = 255;
           end
           
           New(j,k,i) = NewValu;
       end
    end  
end

