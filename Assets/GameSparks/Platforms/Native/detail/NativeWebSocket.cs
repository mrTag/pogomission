#if ((UNITY_SWITCH || UNITY_XBOXONE) && !UNITY_EDITOR) || GS_FORCE_NATIVE_PLATFORM

//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace GameSparksNative.detail {

public class NativeWebSocket : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal NativeWebSocket(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(NativeWebSocket obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~NativeWebSocket() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          GameSparksNativePINVOKE.delete_NativeWebSocket(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public class Result : global::System.IDisposable {
    private global::System.Runtime.InteropServices.HandleRef swigCPtr;
    protected bool swigCMemOwn;
  
    internal Result(global::System.IntPtr cPtr, bool cMemoryOwn) {
      swigCMemOwn = cMemoryOwn;
      swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
    }
  
    internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Result obj) {
      return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
    }
  
    ~Result() {
      Dispose();
    }
  
    public virtual void Dispose() {
      lock(this) {
        if (swigCPtr.Handle != global::System.IntPtr.Zero) {
          if (swigCMemOwn) {
            swigCMemOwn = false;
            GameSparksNativePINVOKE.delete_NativeWebSocket_Result(swigCPtr);
          }
          swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
        }
        global::System.GC.SuppressFinalize(this);
      }
    }
  
    public NativeWebSocket.Result.Type getType() {
      NativeWebSocket.Result.Type ret = (NativeWebSocket.Result.Type)GameSparksNativePINVOKE.NativeWebSocket_Result_getType(swigCPtr);
      return ret;
    }
  
    public string getMessage() {
      string ret = GameSparksNativePINVOKE.NativeWebSocket_Result_getMessage(swigCPtr);
      return ret;
    }
  
    public enum Type {
      Close,
      Open,
      Error,
      Message
    }
  
  }

  public NativeWebSocket() : this(GameSparksNativePINVOKE.new_NativeWebSocket(), true) {
  }

  public void GSExternalOpen(int socketId, string url, string gameObjectName) {
    GameSparksNativePINVOKE.NativeWebSocket_GSExternalOpen(swigCPtr, socketId, url, gameObjectName);
    if (GameSparksNativePINVOKE.SWIGPendingException.Pending) throw GameSparksNativePINVOKE.SWIGPendingException.Retrieve();
  }

  public void GSExternalClose(int socketId) {
    GameSparksNativePINVOKE.NativeWebSocket_GSExternalClose(swigCPtr, socketId);
  }

  public void GSExternalSend(int socketId, string message) {
    GameSparksNativePINVOKE.NativeWebSocket_GSExternalSend(swigCPtr, socketId, message);
    if (GameSparksNativePINVOKE.SWIGPendingException.Pending) throw GameSparksNativePINVOKE.SWIGPendingException.Retrieve();
  }

  public bool Update(float dt) {
    bool ret = GameSparksNativePINVOKE.NativeWebSocket_Update(swigCPtr, dt);
    return ret;
  }

  public NativeWebSocket.Result GetNextResult() {
    global::System.IntPtr cPtr = GameSparksNativePINVOKE.NativeWebSocket_GetNextResult(swigCPtr);
    NativeWebSocket.Result ret = (cPtr == global::System.IntPtr.Zero) ? null : new NativeWebSocket.Result(cPtr, true);
    return ret;
  }

}

}


#endif