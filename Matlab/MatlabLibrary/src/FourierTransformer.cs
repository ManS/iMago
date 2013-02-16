/*
* MATLAB Compiler: 4.13 (R2010a)
* Date: Sat Oct 30 19:56:06 2010
* Arguments: "-B" "macro_default" "-W"
* "dotnet:MatlabLibrary,FourierTransformer,0.0,private" "-T" "link:lib" "-d"
* "D:\Knowledge\Graduation Project\Faculty Tasks\Image Processing
* Tasks\Matlab\MatlabLibrary\src" "-w" "enable:specified_file_mismatch" "-w"
* "enable:repeated_file" "-w" "enable:switch_ignored" "-w" "enable:missing_lib_sentinel"
* "-w" "enable:demo_license" "-v" "class{FourierTransformer:D:\Knowledge\Graduation
* Project\Faculty Tasks\Image Processing
* Tasks\Matlab\M-Files\FourierTransform.m,D:\Knowledge\Graduation Project\Faculty
* Tasks\Image Processing Tasks\Matlab\M-Files\InverseFourierTransform.m}" 
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

namespace MatlabLibrary
{
  /// <summary>
  /// The FourierTransformer class provides a CLS compliant, MWArray interface to the
  /// M-functions contained in the files:
  /// <newpara></newpara>
  /// D:\Knowledge\Graduation Project\Faculty Tasks\Image Processing
  /// Tasks\Matlab\M-Files\FourierTransform.m
  /// <newpara></newpara>
  /// D:\Knowledge\Graduation Project\Faculty Tasks\Image Processing
  /// Tasks\Matlab\M-Files\InverseFourierTransform.m
  /// <newpara></newpara>
  /// deployprint.m
  /// <newpara></newpara>
  /// printdlg.m
  /// </summary>
  /// <remarks>
  /// @Version 0.0
  /// </remarks>
  public class FourierTransformer : IDisposable
  {
    #region Constructors

    /// <summary internal= "true">
    /// The static constructor instantiates and initializes the MATLAB Compiler Runtime
    /// instance.
    /// </summary>
    static FourierTransformer()
    {
      if (MWMCR.MCRAppInitialized)
      {
        Assembly assembly= Assembly.GetExecutingAssembly();

        string ctfFilePath= assembly.Location;

        int lastDelimiter= ctfFilePath.LastIndexOf(@"\");

        ctfFilePath= ctfFilePath.Remove(lastDelimiter, (ctfFilePath.Length - lastDelimiter));

        string ctfFileName = MCRComponentState.MCC_MatlabLibrary_name_data + ".ctf";

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
        mcr= new MWMCR(MCRComponentState.MCC_MatlabLibrary_name_data,
                       MCRComponentState.MCC_MatlabLibrary_root_data,
                       MCRComponentState.MCC_MatlabLibrary_public_data,
                       MCRComponentState.MCC_MatlabLibrary_session_data,
                       MCRComponentState.MCC_MatlabLibrary_matlabpath_data,
                       MCRComponentState.MCC_MatlabLibrary_classpath_data,
                       MCRComponentState.MCC_MatlabLibrary_libpath_data,
                       MCRComponentState.MCC_MatlabLibrary_mcr_application_options,
                       MCRComponentState.MCC_MatlabLibrary_mcr_runtime_options,
                       MCRComponentState.MCC_MatlabLibrary_mcr_pref_dir,
                       MCRComponentState.MCC_MatlabLibrary_set_warning_state,
                       ctfFilePath, embeddedCtfStream, true);
      }
      else
      {
        throw new ApplicationException("MWArray assembly could not be initialized");
      }
    }


    /// <summary>
    /// Constructs a new instance of the FourierTransformer class.
    /// </summary>
    public FourierTransformer()
    {
    }


    #endregion Constructors

    #region Finalize

    /// <summary internal= "true">
    /// Class destructor called by the CLR garbage collector.
    /// </summary>
    ~FourierTransformer()
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
    /// Provides a single output, 0-input MWArrayinterface to the FourierTransform
    /// M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray FourierTransform()
    {
      return mcr.EvaluateFunction("FourierTransform", new MWArray[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input MWArrayinterface to the FourierTransform
    /// M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="InputImage">Input argument #1</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray FourierTransform(MWArray InputImage)
    {
      return mcr.EvaluateFunction("FourierTransform", InputImage);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the FourierTransform
    /// M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] FourierTransform(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "FourierTransform", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the FourierTransform
    /// M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="InputImage">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] FourierTransform(int numArgsOut, MWArray InputImage)
    {
      return mcr.EvaluateFunction(numArgsOut, "FourierTransform", InputImage);
    }


    /// <summary>
    /// Provides an interface for the FourierTransform function in which the input and
    /// output
    /// arguments are specified as an array of MWArrays.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of MWArray output arguments</param>
    /// <param name= "argsIn">Array of MWArray input arguments</param>
    ///
    public void FourierTransform(int numArgsOut, ref MWArray[] argsOut, MWArray[] argsIn)
    {
      mcr.EvaluateFunction("FourierTransform", numArgsOut, ref argsOut, argsIn);
    }


    /// <summary>
    /// Provides a single output, 0-input MWArrayinterface to the InverseFourierTransform
    /// M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray InverseFourierTransform()
    {
      return mcr.EvaluateFunction("InverseFourierTransform", new MWArray[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input MWArrayinterface to the InverseFourierTransform
    /// M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="Real">Input argument #1</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray InverseFourierTransform(MWArray Real)
    {
      return mcr.EvaluateFunction("InverseFourierTransform", Real);
    }


    /// <summary>
    /// Provides a single output, 2-input MWArrayinterface to the InverseFourierTransform
    /// M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="Real">Input argument #1</param>
    /// <param name="Imag">Input argument #2</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray InverseFourierTransform(MWArray Real, MWArray Imag)
    {
      return mcr.EvaluateFunction("InverseFourierTransform", Real, Imag);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the InverseFourierTransform
    /// M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] InverseFourierTransform(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "InverseFourierTransform", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the InverseFourierTransform
    /// M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="Real">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] InverseFourierTransform(int numArgsOut, MWArray Real)
    {
      return mcr.EvaluateFunction(numArgsOut, "InverseFourierTransform", Real);
    }


    /// <summary>
    /// Provides the standard 2-input MWArray interface to the InverseFourierTransform
    /// M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="Real">Input argument #1</param>
    /// <param name="Imag">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] InverseFourierTransform(int numArgsOut, MWArray Real, MWArray Imag)
    {
      return mcr.EvaluateFunction(numArgsOut, "InverseFourierTransform", Real, Imag);
    }


    /// <summary>
    /// Provides an interface for the InverseFourierTransform function in which the input
    /// and output
    /// arguments are specified as an array of MWArrays.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of MWArray output arguments</param>
    /// <param name= "argsIn">Array of MWArray input arguments</param>
    ///
    public void InverseFourierTransform(int numArgsOut, ref MWArray[] argsOut, MWArray[] 
                              argsIn)
    {
      mcr.EvaluateFunction("InverseFourierTransform", numArgsOut, ref argsOut, argsIn);
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
