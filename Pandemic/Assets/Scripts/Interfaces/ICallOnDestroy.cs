using System;

public interface ICallOnDestroy
{
    void SetupCallOnDestroy(Action toCall);
}