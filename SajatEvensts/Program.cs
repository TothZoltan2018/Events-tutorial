using System;

namespace SajatEvensts
{
	public class Program
	{
		static void Main(string[] args)
		{
			Publisher pub = new Publisher();
			Subscriber1 sub1 = new Subscriber1();
			Subscriber2 sub2 = new Subscriber2();

			// subscribe the Subscribers for the event will happen in the Publisher
			pub.EventHappened += sub1.EventHandler1;
			pub.EventHappened += sub2.EventHandler2;
			pub.EventHappened += sub2.EventHandler3;

			// Run the metod in which the event will occure
			pub.AMethodWhereSomethingNoticableWillHappen("I will be an EventArg");
		}
	}

	public class Publisher
	{
		public event EventHandler<SpecialArgsForThisEvent> EventHappened; // Define an event

		public void AMethodWhereSomethingNoticableWillHappen(string something)
		{
			// event need to be fired now
			OnSomethingHappened(something); // Calls the method which will fire the event
		}

		public void OnSomethingHappened(string thing)
		{
			if (EventHappened != null)
			{
				EventHappened(this, new SpecialArgsForThisEvent() { Something = thing }); // Fires the event
			}
		}
	}

	public class SpecialArgsForThisEvent : EventArgs
	{
		public string Something { get; set; }
	}

	public class Subscriber1
	{
		public void EventHandler1(object source, SpecialArgsForThisEvent e) //Event handler method. Sinature corresponds to the event
		{
			// do something, perhaps using the SpecialArgsForThisEvent
			Console.WriteLine($"Subscriber1.EventHandler1: Event raised in: {source}, EventArgs: {e.Something}");
		}
	}

	public class Subscriber2
	{
		public void EventHandler2(object source, SpecialArgsForThisEvent e)
		{
			// do something, perhaps using the SpecialArgsForThisEvent
			Console.WriteLine($"Subscriber2.EventHandler1: Event raised in: {source}, EventArgs: {e.Something}");
		}

		public void EventHandler3(object source, SpecialArgsForThisEvent e)
		{
			// do something, perhaps using the SpecialArgsForThisEvent
			Console.WriteLine($"Subscriber2.EventHandler2: Event raised in: {source}, EventArgs: {e.Something}");
		}
	}
}
