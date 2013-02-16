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

namespace MatlabFunctionsNative
{
  /// <summary>
  /// The Histogram class provides a CLS compliant, Object (native) interface to the
  /// M-functions contained in the files:
  /// <newpara></newpara>
  /// D:\Knowledge\Talking Glasses\Faculty Tasks\Image Processing
  /// Tasks\Matlab\M-Files\HistEqualization.m
  /// <newpara></newpara>
  /// D:\Knowledge\Talking Glasses\Faculty Tasks\Image Processing
  /// Tasks\Matlab\M-Files\histslicing.m
  /// <newpara></newpara>
  /// D:\Knowledge\Talking Glasses\Faculty Tasks\Image Processing
  /// Tasks\Matlab\M-Files\LocalHE.m
  /// <newpara></newpara>
  /// D:\Knowledge\Talking Glasses\Faculty Tasks\Image Processing
  /// Tasks\Matlab\M-Files\LocalStat.m
  /// </summary>
  /// <remarks>
  /// @Version 0.0
  /// </remarks>
  public class Histogram : IDisposable
  {
    #region Constructors

    /// <summary internal= "true">
    /// The static constructor instantiates and initializes the MATLAB Compiler Runtime
    /// instance.
    /// </summary>
    static Histogram()
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
    /// Constructs a new instance of the Histogram class.
    /// </summary>
    public Histogram()
    {
    }


    #endregion Constructors

    #region Finalize

    /// <summary internal= "true">
    /// Class destructor called by the CLR garbage collector.
    /// </summary>
    ~Histogram()
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
    /// Provides a single output, 0-input Objectinterface to the HistEqualization
    /// M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object HistEqualization()
    {
      return mcr.EvaluateFunction("HistEqualization", new Object[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input Objectinterface to the HistEqualization
    /// M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="img">Input argument #1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object HistEqualization(Object img)
    {
      return mcr.EvaluateFunction("HistEqualization", img);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the HistEqualization
    /// M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] HistEqualization(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "HistEqualization", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the HistEqualization
    /// M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="img">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] HistEqualization(int numArgsOut, Object img)
    {
      return mcr.EvaluateFunction(numArgsOut, "HistEqualization", img);
    }


    /// <summary>
    /// Provides a single output, 0-input Objectinterface to the histslicing M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object histslicing()
    {
      return mcr.EvaluateFunction("histslicing", new Object[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input Objectinterface to the histslicing M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="Old">Input argument #1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object histslicing(Object Old)
    {
      return mcr.EvaluateFunction("histslicing", Old);
    }


    /// <summary>
    /// Provides a single output, 2-input Objectinterface to the histslicing M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="Old">Input argument #1</param>
    /// <param name="OldMin">Input argument #2</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object histslicing(Object Old, Object OldMin)
    {
      return mcr.EvaluateFunction("histslicing", Old, OldMin);
    }


    /// <summary>
    /// Provides a single output, 3-input Objectinterface to the histslicing M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="Old">Input argument #1</param>
    /// <param name="OldMin">Input argument #2</param>
    /// <param name="OldMax">Input argument #3</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object histslicing(Object Old, Object OldMin, Object OldMax)
    {
      return mcr.EvaluateFunction("histslicing", Old, OldMin, OldMax);
    }


    /// <summary>
    /// Provides a single output, 4-input Objectinterface to the histslicing M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="Old">Input argument #1</param>
    /// <param name="OldMin">Input argument #2</param>
    /// <param name="OldMax">Input argument #3</param>
    /// <param name="NewVal">Input argument #4</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object histslicing(Object Old, Object OldMin, Object OldMax, Object NewVal)
    {
      return mcr.EvaluateFunction("histslicing", Old, OldMin, OldMax, NewVal);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the histslicing M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] histslicing(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "histslicing", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the histslicing M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="Old">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] histslicing(int numArgsOut, Object Old)
    {
      return mcr.EvaluateFunction(numArgsOut, "histslicing", Old);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the histslicing M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="Old">Input argument #1</param>
    /// <param name="OldMin">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] histslicing(int numArgsOut, Object Old, Object OldMin)
    {
      return mcr.EvaluateFunction(numArgsOut, "histslicing", Old, OldMin);
    }


    /// <summary>
    /// Provides the standard 3-input Object interface to the histslicing M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="Old">Input argument #1</param>
    /// <param name="OldMin">Input argument #2</param>
    /// <param name="OldMax">Input argument #3</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] histslicing(int numArgsOut, Object Old, Object OldMin, Object OldMax)
    {
      return mcr.EvaluateFunction(numArgsOut, "histslicing", Old, OldMin, OldMax);
    }


    /// <summary>
    /// Provides the standard 4-input Object interface to the histslicing M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="Old">Input argument #1</param>
    /// <param name="OldMin">Input argument #2</param>
    /// <param name="OldMax">Input argument #3</param>
    /// <param name="NewVal">Input argument #4</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] histslicing(int numArgsOut, Object Old, Object OldMin, Object OldMax, 
                          Object NewVal)
    {
      return mcr.EvaluateFunction(numArgsOut, "histslicing", Old, OldMin, OldMax, NewVal);
    }


    /// <summary>
    /// Provides a single output, 0-input Objectinterface to the LocalHE M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object LocalHE()
    {
      return mcr.EvaluateFunction("LocalHE", new Object[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input Objectinterface to the LocalHE M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="WinSize">Input argument #1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object LocalHE(Object WinSize)
    {
      return mcr.EvaluateFunction("LocalHE", WinSize);
    }


    /// <summary>
    /// Provides a single output, 2-input Objectinterface to the LocalHE M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="WinSize">Input argument #1</param>
    /// <param name="Img">Input argument #2</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object LocalHE(Object WinSize, Object Img)
    {
      return mcr.EvaluateFunction("LocalHE", WinSize, Img);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the LocalHE M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] LocalHE(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "LocalHE", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the LocalHE M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="WinSize">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] LocalHE(int numArgsOut, Object WinSize)
    {
      return mcr.EvaluateFunction(numArgsOut, "LocalHE", WinSize);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the LocalHE M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="WinSize">Input argument #1</param>
    /// <param name="Img">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] LocalHE(int numArgsOut, Object WinSize, Object Img)
    {
      return mcr.EvaluateFunction(numArgsOut, "LocalHE", WinSize, Img);
    }


    /// <summary>
    /// Provides a single output, 0-input Objectinterface to the LocalStat M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object LocalStat()
    {
      return mcr.EvaluateFunction("LocalStat", new Object[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input Objectinterface to the LocalStat M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="WinSize">Input argument #1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object LocalStat(Object WinSize)
    {
      return mcr.EvaluateFunction("LocalStat", WinSize);
    }


    /// <summary>
    /// Provides a single output, 2-input Objectinterface to the LocalStat M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="WinSize">Input argument #1</param>
    /// <param name="K0">Input argument #2</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object LocalStat(Object WinSize, Object K0)
    {
      return mcr.EvaluateFunction("LocalStat", WinSize, K0);
    }


    /// <summary>
    /// Provides a single output, 3-input Objectinterface to the LocalStat M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="WinSize">Input argument #1</param>
    /// <param name="K0">Input argument #2</param>
    /// <param name="K1">Input argument #3</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object LocalStat(Object WinSize, Object K0, Object K1)
    {
      return mcr.EvaluateFunction("LocalStat", WinSize, K0, K1);
    }


    /// <summary>
    /// Provides a single output, 4-input Objectinterface to the LocalStat M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="WinSize">Input argument #1</param>
    /// <param name="K0">Input argument #2</param>
    /// <param name="K1">Input argument #3</param>
    /// <param name="K2">Input argument #4</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object LocalStat(Object WinSize, Object K0, Object K1, Object K2)
    {
      return mcr.EvaluateFunction("LocalStat", WinSize, K0, K1, K2);
    }


    /// <summary>
    /// Provides a single output, 5-input Objectinterface to the LocalStat M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="WinSize">Input argument #1</param>
    /// <param name="K0">Input argument #2</param>
    /// <param name="K1">Input argument #3</param>
    /// <param name="K2">Input argument #4</param>
    /// <param name="E">Input argument #5</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object LocalStat(Object WinSize, Object K0, Object K1, Object K2, Object E)
    {
      return mcr.EvaluateFunction("LocalStat", WinSize, K0, K1, K2, E);
    }


    /// <summary>
    /// Provides a single output, 6-input Objectinterface to the LocalStat M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="WinSize">Input argument #1</param>
    /// <param name="K0">Input argument #2</param>
    /// <param name="K1">Input argument #3</param>
    /// <param name="K2">Input argument #4</param>
    /// <param name="E">Input argument #5</param>
    /// <param name="M">Input argument #6</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object LocalStat(Object WinSize, Object K0, Object K1, Object K2, Object E, 
                      Object M)
    {
      return mcr.EvaluateFunction("LocalStat", WinSize, K0, K1, K2, E, M);
    }


    /// <summary>
    /// Provides a single output, 7-input Objectinterface to the LocalStat M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="WinSize">Input argument #1</param>
    /// <param name="K0">Input argument #2</param>
    /// <param name="K1">Input argument #3</param>
    /// <param name="K2">Input argument #4</param>
    /// <param name="E">Input argument #5</param>
    /// <param name="M">Input argument #6</param>
    /// <param name="Var">Input argument #7</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object LocalStat(Object WinSize, Object K0, Object K1, Object K2, Object E, 
                      Object M, Object Var)
    {
      return mcr.EvaluateFunction("LocalStat", WinSize, K0, K1, K2, E, M, Var);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the LocalStat M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] LocalStat(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "LocalStat", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the LocalStat M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="WinSize">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] LocalStat(int numArgsOut, Object WinSize)
    {
      return mcr.EvaluateFunction(numArgsOut, "LocalStat", WinSize);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the LocalStat M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="WinSize">Input argument #1</param>
    /// <param name="K0">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] LocalStat(int numArgsOut, Object WinSize, Object K0)
    {
      return mcr.EvaluateFunction(numArgsOut, "LocalStat", WinSize, K0);
    }


    /// <summary>
    /// Provides the standard 3-input Object interface to the LocalStat M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="WinSize">Input argument #1</param>
    /// <param name="K0">Input argument #2</param>
    /// <param name="K1">Input argument #3</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] LocalStat(int numArgsOut, Object WinSize, Object K0, Object K1)
    {
      return mcr.EvaluateFunction(numArgsOut, "LocalStat", WinSize, K0, K1);
    }


    /// <summary>
    /// Provides the standard 4-input Object interface to the LocalStat M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="WinSize">Input argument #1</param>
    /// <param name="K0">Input argument #2</param>
    /// <param name="K1">Input argument #3</param>
    /// <param name="K2">Input argument #4</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] LocalStat(int numArgsOut, Object WinSize, Object K0, Object K1, 
                        Object K2)
    {
      return mcr.EvaluateFunction(numArgsOut, "LocalStat", WinSize, K0, K1, K2);
    }


    /// <summary>
    /// Provides the standard 5-input Object interface to the LocalStat M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="WinSize">Input argument #1</param>
    /// <param name="K0">Input argument #2</param>
    /// <param name="K1">Input argument #3</param>
    /// <param name="K2">Input argument #4</param>
    /// <param name="E">Input argument #5</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] LocalStat(int numArgsOut, Object WinSize, Object K0, Object K1, 
                        Object K2, Object E)
    {
      return mcr.EvaluateFunction(numArgsOut, "LocalStat", WinSize, K0, K1, K2, E);
    }


    /// <summary>
    /// Provides the standard 6-input Object interface to the LocalStat M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="WinSize">Input argument #1</param>
    /// <param name="K0">Input argument #2</param>
    /// <param name="K1">Input argument #3</param>
    /// <param name="K2">Input argument #4</param>
    /// <param name="E">Input argument #5</param>
    /// <param name="M">Input argument #6</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] LocalStat(int numArgsOut, Object WinSize, Object K0, Object K1, 
                        Object K2, Object E, Object M)
    {
      return mcr.EvaluateFunction(numArgsOut, "LocalStat", WinSize, K0, K1, K2, E, M);
    }


    /// <summary>
    /// Provides the standard 7-input Object interface to the LocalStat M-function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="WinSize">Input argument #1</param>
    /// <param name="K0">Input argument #2</param>
    /// <param name="K1">Input argument #3</param>
    /// <param name="K2">Input argument #4</param>
    /// <param name="E">Input argument #5</param>
    /// <param name="M">Input argument #6</param>
    /// <param name="Var">Input argument #7</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] LocalStat(int numArgsOut, Object WinSize, Object K0, Object K1, 
                        Object K2, Object E, Object M, Object Var)
    {
      return mcr.EvaluateFunction(numArgsOut, "LocalStat", WinSize, K0, K1, K2, E, M, Var);
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
