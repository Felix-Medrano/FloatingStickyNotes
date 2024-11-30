namespace FloatingStickyNotes.Patterns.Observer.Interfaces
{
  public abstract class IObserver
  {
    public abstract void Update(ISubject subject);
  }
}
