function [Real,Imaginery] = FourierTransform (InputImage)
Complex = fft2(InputImage);
Shifted=fftshift(Complex);
Real=real(Shifted);
Imaginery=imag(Shifted);
end