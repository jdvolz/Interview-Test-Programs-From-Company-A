/*
 * Author:  Joshua Volz
 * email:   jdvolz@gmail.com
 * cell:    909-957-4278
 * test:    Swap Pairs of Element in List
 * Date:    Sunday May 18th
 */

using System;

namespace LinkedList
{
    class LinkedList
    {
        /// <summary>
        /// I'm using Main to run tests on the swapPairs function.  The tests consist of different general scenarios including:
        /// - 0 length list
        /// - 1 length list
        /// - 2 length list 
        /// - 4 length list (even length with swapping)
        /// - 5 length list (odd length with swapping)
        /// - 4 length circular list (even length with circular)
        /// - 5 length circular list (odd length with circular)
        /// 
        /// All tests appear to pass at this time.  Normally, I would use something like NUnit for testing, 
        /// but I didn't want this code to be dependent on an additional library.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //length = 0
            try
            {
                swapPairs(null);
            }
            catch (ArgumentException) {
                Console.WriteLine("Argument Exception caught for null");
            }

            //length = 1
            Node single = new Node();
            single.n = 1;
            single.next = null;
            PrintNodes(single);
            PrintNodes(swapPairs(single));

            //length = 2
            Node dub = new Node();
            dub.n = 1;
            Node dub2 = new Node();
            dub2.n = 2;
            dub.next = dub2;

            PrintNodes(dub);
            PrintNodes(swapPairs(dub));

            //length = 4
            Node quad1 = new Node();
            quad1.n = 1;
            Node quad2 = new Node();
            quad2.n = 2;
            Node quad3 = new Node();
            quad3.n = 3;
            Node quad4 = new Node();
            quad4.n = 4;

            quad1.next = quad2;
            quad2.next = quad3;
            quad3.next = quad4;
            quad4.next = null;

            PrintNodes(quad1);
            PrintNodes(swapPairs(quad1));
            
            //length = 5
            Node fiver1 = new Node();
            fiver1.n = 1;
            Node fiver2 = new Node();
            fiver2.n = 2;
            Node fiver3 = new Node();
            fiver3.n = 3;
            Node fiver4 = new Node();
            fiver4.n = 4;
            Node fiver5 = new Node();
            fiver5.n = 5;

            fiver1.next = fiver2;
            fiver2.next = fiver3;
            fiver3.next = fiver4;
            fiver4.next = fiver5;
            fiver5.next = null;

            PrintNodes(fiver1);
            PrintNodes(swapPairs(fiver1));


            //length = 4 circular

            Node quadcir1 = new Node();
            quadcir1.n = 1;
            Node quadcir2 = new Node();
            quadcir2.n = 2;
            Node quadcir3 = new Node();
            quadcir3.n = 3;
            Node quadcir4 = new Node();
            quadcir4.n = 4;

            quadcir1.next = quadcir2;
            quadcir2.next = quadcir3;
            quadcir3.next = quadcir4;
            quadcir4.next = null;

            PrintNodes(quadcir1);
            PrintNodes(swapPairs(quadcir1));

            //length = 5 circular
            Node fivercir1 = new Node();
            fivercir1.n = 1;
            Node fivercir2 = new Node();
            fivercir2.n = 2;
            Node fivercir3 = new Node();
            fivercir3.n = 3;
            Node fivercir4 = new Node();
            fivercir4.n = 4;
            Node fivercir5 = new Node();
            fivercir5.n = 5;

            fivercir1.next = fivercir2;
            fivercir2.next = fivercir3;
            fivercir3.next = fivercir4;
            fivercir4.next = fivercir5;
            fivercir5.next = null;

            PrintNodes(fivercir1);
            PrintNodes(swapPairs(fivercir1));
        }

        public static void PrintNodes(Node head) {
            Console.Out.WriteLine("{0} ", head.n);
            Node next = head.next;
            while (null != next && next != head) {
                Console.Out.WriteLine("{0} ", next.n);
                next = next.next;
            }
        }

        public static Node swapPairs(Node head) { 
            //check for zero length, throw exception
            if (null == head) throw new ArgumentException("Head must be a Node object and not null.");
            //otherwise call helper
            return swapPairsHelper(head, null, null, null, true);
        }

        /// <summary>
        /// The real workhorse of this program, meant to do the swapping, check for circular lists 
        /// and finally return the "new head" of the list (the 2nd Node in a length > 1 list)
        /// 
        /// This function is recursive, which made it easier to write but for very long lists 
        /// there may be problems with running out of stack frames because C# (far as I know) does not
        /// perform tail call optimization (where as a language like Scheme would).  This function 
        /// could have easily been written as a while loop which has the advantage of not using up 
        /// stack frames, but is also harder to write for some recursive functions.  It was easier to make
        /// it recursive for me.
        /// 
        /// It may be possible to optimize the number and types of arguments sent to the Helper function.
        /// 
        /// It may be possible to optimize the number and type of if statements as well, though this 
        /// configuration is pretty easy to understand with the comments.
        /// 
        /// </summary>
        /// <param name="work"></param>
        /// <param name="prev"></param>
        /// <param name="oldHead"></param>
        /// <param name="newHead"></param>
        /// <param name="justStarted"></param>
        /// <returns></returns>
        private static Node swapPairsHelper(Node work, Node prev, Node oldHead, Node newHead, bool justStarted) {            
            
            //stopping conditions:
            //1.  Either the work == null or work.next == null
            //2.  work == oldHead 
            if( null == work || 
                null == work.next ){
                    //we're done with a non-circular list, return work if list length == 1, else newHead
                    if (justStarted) return work;
                    else return newHead;
            }
            if((work == oldHead && !justStarted)){
                //we're done with a circular list, return the newHead
                return newHead;
            }
            if (justStarted)
            {
                //we just started the process, set the old head
                oldHead = work;
                //set the new head too
                newHead = work.next;
            }
            else {
                //we didn't just start, which means we need to set the prev.next
                prev.next = work.next;
            }

            Node second = work.next;
            work.next = second.next;
            second.next = work;
            return swapPairsHelper(work.next, work, oldHead, newHead, false);
        }
    }

    public class Node {
        public int n;  //value of element
        public Node next;  //pointer to next element in list
    }    
}

//Start time:       3:33pm
//End coding time:  4:28pm
//End test Time:    4:39pm (made some notes and comments)