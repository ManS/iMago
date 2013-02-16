/*
* MATLAB Compiler: 4.13 (R2010a)
* Date: Sun Dec 26 21:51:48 2010
* Arguments: "-B" "macro_default" "-W" "dotnet:MatlabFunctions,Retinex,0.0,private" "-T"
* "link:lib" "-d" "D:\Knowledge\Talking Glasses\Faculty Tasks\Image Processing
* Tasks\Matlab\M-Files\MatlabFunctions\src" "-w" "enable:specified_file_mismatch" "-w"
* "enable:repeated_file" "-w" "enable:switch_ignored" "-w" "enable:missing_lib_sentinel"
* "-w" "enable:demo_license" "-v" "class{Retinex:D:\Knowledge\Talking Glasses\Faculty
* Tasks\Image Processing Tasks\Matlab\M-Files\FastRetinex.m,D:\Knowledge\Talking
* Glasses\Faculty Tasks\Image Processing Tasks\Matlab\M-Files\MSR.m,D:\Knowledge\Talking
* Glasses\Faculty Tasks\Image Processing Tasks\Matlab\M-Files\SingleScaleRetinex.m}"
* "class{Histogram:D:\Knowledge\Talking Glasses\Faculty Tasks\Image Processing
* Tasks\Matlab\M-Files\HistEqualization.m,D:\Knowledge\Talking Glasses\Faculty
* Tasks\Image Processing Tasks\Matlab\M-Files\histslicing.m,D:\Knowledge\Talking
* Glasses\Faculty Tasks\Image Processing
* Tasks\Matlab\M-Files\LocalHE.m,D:\Knowledge\Talking Glasses\Faculty Tasks\Image
* Processing Tasks\Matlab\M-Files\LocalStat.m}" 
*/
using System;
using System.Reflection;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.ComponentData;

#if SHARED
[assembly: System.Reflection.AssemblyKeyFile(@"")]
#endif

namespace MatlabFunctionsNative
{
  /// <summary>
  /// The Retinex class provides a CLS compliant, Object (native) interface to the
  /// M-functions contained in the files:
  /// <newpara></newpara>
  /// D:\Knowledge\Talking Glasses\Faculty Tasks\Image Processing
  /// Tasks\Matlab\M-Files\FastRetinex.m
  /// <newpara></newpara>
  /// D:\Knowledge\Talking Glasses\Faculty Tasks\Image Processing
  /// Tasks\Matlab\M-Files\MSR.m
  /// <newpara></newpara>
  /// D:\Knowledge\Talking Glasses\Faculty Tasks\Image Processing
  /// Tasks\Matlab\M-Files\SingleScaleRetinex.m
  /// <newpara></newpara>
  /// deployprint.m
  /// <newpara></newpara>
  /// printdlg.m
  /// </summary>
  /// <remarks>
  /// @Version 0.0
  /// </remarks>
  public class Retinex : IDisposable
  {
    #region Constructors

    /// <summary internal= "true">
    /// The static constructor instantiates and initializes the MATLAB Compiler Runtime
    /// instance.
    /// </summary>
    static Retinex()
    {
      if (MWMCR.MCRAppInitialized)
      {
        Assembly assembly= Assembly.GetExecutingAssembly();

        string ctfFilePath= assembly.Location;

        int lastDelimiter= ctfFilePath.LastIndexOf(@"\");

        ctfFilePath= ctfFilePath.Remove(lastDelimiter, (ctfFilePath.Length - lastDelimiter));

        string ctfFileName = MCRComponentState.MCC_MatlabFunctions_name_data + ".ctf";

        Stream embeddedCtfStream = null;

        String[] resourceStrings = assembly.GetManifestResourceNames();

        foreach (String name in resourceStrings)
        {
          if (name.Contains(ctfFileName))
          {
            embeddedCtfStream = assembly.GetManifestResourceStream(name);
            break;
          }
        }
        mcr= new MWMCR(MCRComponentState.MCC_MatlabFunctions_name_data,
                       MCRComponentState.MCC_MatlabFunctions_root_data,
                       MCRComponentState.MCC_MatlabFunctions_public_data,
                       MCRComponentState.MCC_MatlabFunctions_session_data,
                       MCRComponentState.MCC_MatlabFunctions_matlabpath_data,
                       MCRComponentState.MCC_MatlabFunctions_classpath_data,
                       MCRComponentState.MCC_MatlabFunctions_libpath_data,
                       MCRComponentState.MCC_MatlabFunctions_mcr_application_options,
                       MCRComponentState.MCC_MatlabFunctions_mcr_runtime_options,
                       MCRComponentState.MCC_MatlabFunctions_mcr_pref_dir,
                       MCRComponentState.MCC_MatlabFunctions_set_warning_state,
                       ctfFilePath, embeddedCtfStream, true);
      }
      else
      {
        throw new ApplicationException("MWArray assembly could not be initialized");
      }
    }


    /// <summary>
    /// Constructs a new instance of the Retinex class.
    /// </summary>
    public Retinex()
    {
    }


    #endregion Constructors

    #region Finalize

    /// <summary internal= "true">
    /// Class destructor called by the CLR garbage collector.
    /// </summary>
    ~Retinex()
    {
      Dispose(false);
    }


    /// <summary>
    /// Frees the native resources associated with this object
    /// </summary>
    public void Dispose()
    {
      Dispose(true);

      GC.SuppressFinalize(this);
    }


    /// <summary internal= "true">
    /// Internal dispose function
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
      if (!disposed)
      {
        disposed= true;

        if (disposing)
        {
          // Free managed resources;
        }

        // Free native resources
      }
    }


    #endregion Finalize

    #region Methods

    /// <summary>
    /// Provides a single output, 0-input Objectinterface to the FastRetinex M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object FastRetinex()
    {
      return mcr.EvaluateFunction("FastRetinex", new Object[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input Objectinterface to the FastRetinex M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="sigm">Input argument #1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object FastRetinex(Object sigm)
    {
      return mcr.EvaluateFunction("FastRetinex", sigm);
    }


    /// <summary>
    /// Provides a single output, 2-input Objectinterface to the FastRetinex M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="sigm">Input argument #1</param>
    /// <param name="Img">Input argument #2</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object FastRetinex(Object sigm, Object Img)
    {
      return mcr.EvaluateFunction("FastRetinex", sigm, Img);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the FastRetinex M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] FastRetinex(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "FastRetinex", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the FastRetinex M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="sigm">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] FastRetinex(int numArgsOut, Object sigm)
    {
      return mcr.EvaluateFunction(numArgsOut, "FastRetinex", sigm);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the FastRetinex M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="sigm">Input argument #1</param>
    /// <param name="Img">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] FastRetinex(int numArgsOut, Object sigm, Object Img)
    {
      return mcr.EvaluateFunction(numArgsOut, "FastRetinex", sigm, Img);
    }


    /// <summary>
    /// Provides a single output, 0-input Objectinterface to the MSR M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object MSR()
    {
      return mcr.EvaluateFunction("MSR", new Object[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input Objectinterface to the MSR M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="OldImage">Input argument #1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object MSR(Object OldImage)
    {
      return mcr.EvaluateFunction("MSR", OldImage);
    }


    /// <summary>
    /// Provides a single output, 2-input Objectinterface to the MSR M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="OldImage">Input argument #1</param>
    /// <param name="Sigma">Input argument #2</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object MSR(Object OldImage, Object Sigma)
    {
      return mcr.EvaluateFunction("MSR", OldImage, Sigma);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the MSR M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] MSR(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "MSR", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the MSR M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="OldImage">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] MSR(int numArgsOut, Object OldImage)
    {
      return mcr.EvaluateFunction(numArgsOut, "MSR", OldImage);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the MSR M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="OldImage">Input argument #1</param>
    /// <param name="Sigma">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] MSR(int numArgsOut, Object OldImage, Object Sigma)
    {
      return mcr.EvaluateFunction(numArgsOut, "MSR", OldImage, Sigma);
    }


    /// <summary>
    /// Provides a single output, 0-input Objectinterface to the SingleScaleRetinex
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Retinex(:,:,1) = HistEqualization(Retinex(:,:,1));
    /// Retinex(:,:,2) = HistEqualization(Retinex(:,:,2));
    /// Retinex(:,:,3) = HistEqualization(Retinex(:,:,3));
    /// figure, imshow(uint16(Retinex));
    /// Normalization
    /// NewMax = 255;
    /// NewMin = 0;
    /// MaxR = int16(max(max(Retinex(:,:,1))));
    /// MaxG = max(max(Retinex(:,:,2)));
    /// MaxB = max(max(Retinex(:,:,3)));
    /// MinR = min(min(Retinex(:,:,1)));
    /// MinG = min(min(Retinex(:,:,2)));
    /// MinB = min(min(Retinex(:,:,3)));
    /// Retinex(:,:,1) =int16(((double(Retinex(:,:,1)) -
    /// double(MinR))*double(NewMax-NewMin))./double((MaxR - MinR))+double(NewMin));
    /// figure, imshow(uint8(Retinex));
    /// Retinex(:,:,2) = int16(((double(Retinex(:,:,2)) -
    /// double(MinG))*double(NewMax-NewMin))./double((MaxG - MinG))+double(NewMin));
    /// figure, imshow(uint8(Retinex));
    /// Retinex(:,:,3) = int16(((double(Retinex(:,:,3)) -
    /// double(MinB))*double(NewMax-NewMin))./double((MaxB - MinB))+double(NewMin));
    /// imshow(uint16(Retinex));
    /// newImg = uint8(Retinex);</remarks>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object SingleScaleRetinex()
    {
      return mcr.EvaluateFunction("SingleScaleRetinex", new Object[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input Objectinterface to the SingleScaleRetinex
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Retinex(:,:,1) = HistEqualization(Retinex(:,:,1));
    /// Retinex(:,:,2) = HistEqualization(Retinex(:,:,2));
    /// Retinex(:,:,3) = HistEqualization(Retinex(:,:,3));
    /// figure, imshow(uint16(Retinex));
    /// Normalization
    /// NewMax = 255;
    /// NewMin = 0;
    /// MaxR = int16(max(max(Retinex(:,:,1))));
    /// MaxG = max(max(Retinex(:,:,2)));
    /// MaxB = max(max(Retinex(:,:,3)));
    /// MinR = min(min(Retinex(:,:,1)));
    /// MinG = min(min(Retinex(:,:,2)));
    /// MinB = min(min(Retinex(:,:,3)));
    /// Retinex(:,:,1) =int16(((double(Retinex(:,:,1)) -
    /// double(MinR))*double(NewMax-NewMin))./double((MaxR - MinR))+double(NewMin));
    /// figure, imshow(uint8(Retinex));
    /// Retinex(:,:,2) = int16(((double(Retinex(:,:,2)) -
    /// double(MinG))*double(NewMax-NewMin))./double((MaxG - MinG))+double(NewMin));
    /// figure, imshow(uint8(Retinex));
    /// Retinex(:,:,3) = int16(((double(Retinex(:,:,3)) -
    /// double(MinB))*double(NewMax-NewMin))./double((MaxB - MinB))+double(NewMin));
    /// imshow(uint16(Retinex));
    /// newImg = uint8(Retinex);</remarks>
    /// <param name="sigm">Input argument #1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object SingleScaleRetinex(Object sigm)
    {
      return mcr.EvaluateFunction("SingleScaleRetinex", sigm);
    }


    /// <summary>
    /// Provides a single output, 2-input Objectinterface to the SingleScaleRetinex
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Retinex(:,:,1) = HistEqualization(Retinex(:,:,1));
    /// Retinex(:,:,2) = HistEqualization(Retinex(:,:,2));
    /// Retinex(:,:,3) = HistEqualization(Retinex(:,:,3));
    /// figure, imshow(uint16(Retinex));
    /// Normalization
    /// NewMax = 255;
    /// NewMin = 0;
    /// MaxR = int16(max(max(Retinex(:,:,1))));
    /// MaxG = max(max(Retinex(:,:,2)));
    /// MaxB = max(max(Retinex(:,:,3)));
    /// MinR = min(min(Retinex(:,:,1)));
    /// MinG = min(min(Retinex(:,:,2)));
    /// MinB = min(min(Retinex(:,:,3)));
    /// Retinex(:,:,1) =int16(((double(Retinex(:,:,1)) -
    /// double(MinR))*double(NewMax-NewMin))./double((MaxR - MinR))+double(NewMin));
    /// figure, imshow(uint8(Retinex));
    /// Retinex(:,:,2) = int16(((double(Retinex(:,:,2)) -
    /// double(MinG))*double(NewMax-NewMin))./double((MaxG - MinG))+double(NewMin));
    /// figure, imshow(uint8(Retinex));
    /// Retinex(:,:,3) = int16(((double(Retinex(:,:,3)) -
    /// double(MinB))*double(NewMax-NewMin))./double((MaxB - MinB))+double(NewMin));
    /// imshow(uint16(Retinex));
    /// newImg = uint8(Retinex);</remarks>
    /// <param name="sigm">Input argument #1</param>
    /// <param name="Img">Input argument #2</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object SingleScaleRetinex(Object sigm, Object Img)
    {
      return mcr.EvaluateFunction("SingleScaleRetinex", sigm, Img);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the SingleScaleRetinex
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Retinex(:,:,1) = HistEqualization(Retinex(:,:,1));
    /// Retinex(:,:,2) = HistEqualization(Retinex(:,:,2));
    /// Retinex(:,:,3) = HistEqualization(Retinex(:,:,3));
    /// figure, imshow(uint16(Retinex));
    /// Normalization
    /// NewMax = 255;
    /// NewMin = 0;
    /// MaxR = int16(max(max(Retinex(:,:,1))));
    /// MaxG = max(max(Retinex(:,:,2)));
    /// MaxB = max(max(Retinex(:,:,3)));
    /// MinR = min(min(Retinex(:,:,1)));
    /// MinG = min(min(Retinex(:,:,2)));
    /// MinB = min(min(Retinex(:,:,3)));
    /// Retinex(:,:,1) =int16(((double(Retinex(:,:,1)) -
    /// double(MinR))*double(NewMax-NewMin))./double((MaxR - MinR))+double(NewMin));
    /// figure, imshow(uint8(Retinex));
    /// Retinex(:,:,2) = int16(((double(Retinex(:,:,2)) -
    /// double(MinG))*double(NewMax-NewMin))./double((MaxG - MinG))+double(NewMin));
    /// figure, imshow(uint8(Retinex));
    /// Retinex(:,:,3) = int16(((double(Retinex(:,:,3)) -
    /// double(MinB))*double(NewMax-NewMin))./double((MaxB - MinB))+double(NewMin));
    /// imshow(uint16(Retinex));
    /// newImg = uint8(Retinex);</remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] SingleScaleRetinex(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "SingleScaleRetinex", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the SingleScaleRetinex
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Retinex(:,:,1) = HistEqualization(Retinex(:,:,1));
    /// Retinex(:,:,2) = HistEqualization(Retinex(:,:,2));
    /// Retinex(:,:,3) = HistEqualization(Retinex(:,:,3));
    /// figure, imshow(uint16(Retinex));
    /// Normalization
    /// NewMax = 255;
    /// NewMin = 0;
    /// MaxR = int16(max(max(Retinex(:,:,1))));
    /// MaxG = max(max(Retinex(:,:,2)));
    /// MaxB = max(max(Retinex(:,:,3)));
    /// MinR = min(min(Retinex(:,:,1)));
    /// MinG = min(min(Retinex(:,:,2)));
    /// MinB = min(min(Retinex(:,:,3)));
    /// Retinex(:,:,1) =int16(((double(Retinex(:,:,1)) -
    /// double(MinR))*double(NewMax-NewMin))./double((MaxR - MinR))+double(NewMin));
    /// figure, imshow(uint8(Retinex));
    /// Retinex(:,:,2) = int16(((double(Retinex(:,:,2)) -
    /// double(MinG))*double(NewMax-NewMin))./double((MaxG - MinG))+double(NewMin));
    /// figure, imshow(uint8(Retinex));
    /// Retinex(:,:,3) = int16(((double(Retinex(:,:,3)) -
    /// double(MinB))*double(NewMax-NewMin))./double((MaxB - MinB))+double(NewMin));
    /// imshow(uint16(Retinex));
    /// newImg = uint8(Retinex);</remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="sigm">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] SingleScaleRetinex(int numArgsOut, Object sigm)
    {
      return mcr.EvaluateFunction(numArgsOut, "SingleScaleRetinex", sigm);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the SingleScaleRetinex
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Retinex(:,:,1) = HistEqualization(Retinex(:,:,1));
    /// Retinex(:,:,2) = HistEqualization(Retinex(:,:,2));
    /// Retinex(:,:,3) = HistEqualization(Retinex(:,:,3));
    /// figure, imshow(uint16(Retinex));
    /// Normalization
    /// NewMax = 255;
    /// NewMin = 0;
    /// MaxR = int16(max(max(Retinex(:,:,1))));
    /// MaxG = max(max(Retinex(:,:,2)));
    /// MaxB = max(max(Retinex(:,:,3)));
    /// MinR = min(min(Retinex(:,:,1)));
    /// MinG = min(min(Retinex(:,:,2)));
    /// MinB = min(min(Retinex(:,:,3)));
    /// Retinex(:,:,1) =int16(((double(Retinex(:,:,1)) -
    /// double(MinR))*double(NewMax-NewMin))./double((MaxR - MinR))+double(NewMin));
    /// figure, imshow(uint8(Retinex));
    /// Retinex(:,:,2) = int16(((double(Retinex(:,:,2)) -
    /// double(MinG))*double(NewMax-NewMin))./double((MaxG - MinG))+double(NewMin));
    /// figure, imshow(uint8(Retinex));
    /// Retinex(:,:,3) = int16(((double(Retinex(:,:,3)) -
    /// double(MinB))*double(NewMax-NewMin))./double((MaxB - MinB))+double(NewMin));
    /// imshow(uint16(Retinex));
    /// newImg = uint8(Retinex);</remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="sigm">Input argument #1</param>
    /// <param name="Img">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] SingleScaleRetinex(int numArgsOut, Object sigm, Object Img)
    {
      return mcr.EvaluateFunction(numArgsOut, "SingleScaleRetinex", sigm, Img);
    }


    /// <summary>
    /// This method will cause a MATLAB figure window to behave as a modal dialog box.
    /// The method will not return until all the figure windows associated with this
    /// component have been closed.
    /// </summary>
    /// <remarks>
    /// An application should only call this method when required to keep the
    /// MATLAB figure window from disappearing.  Other techniques, such as calling
    /// Console.ReadLine() from the application should be considered where
    /// possible.</remarks>
    ///
    public void WaitForFiguresToDie()
    {
      mcr.WaitForFiguresToDie();
    }



    #endregion Methods

    #region Class Members

    private static MWMCR mcr= null;

    private bool disposed= false;

    #endregion Class Members
  }
}
