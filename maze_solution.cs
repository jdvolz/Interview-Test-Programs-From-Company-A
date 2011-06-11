public static bool CanEscape(Maze m)

        {

            //hash for visited square            

            Dictionary<Point, object> visited = new Dictionary<Point, object>();            

            //depth first search on 4 children tree

            //check left, backward, right, forward

            return CanEscapeHelper(m, visited, new Point(0,0));

        }

 

        private static bool CanEscapeHelper(Maze m, Dictionary<Point, object> visited, Point location) {

 

            //check to see if we've reach our max count

            if (visited.Count == 10000) { return false; }

 

            //check to see if we've already been here

            if (visited.ContainsKey(location)) { return false; }

 

            //check to see if here is a success

            if (m.Success()) { return true; }

 

            bool result = false;

            //-or- together the results of searching the tree.

            if (m.Move(Direction.left))

            {

                //move was success

                //recurse

                Point new_location = new Point(location.X-1, location.Y);

                visited[new_location] = new object();

                result = result || CanEscapeHelper(m, visited, new_location);

                if (result) return true; //we found a path return without recursing

                m.Move(Direction.right); //move the state of the maze back to location

            }

            else { 

                //move failed

                Point new_location = new Point(location.X - 1, location.Y);

                visited[new_location] = new object();

            }

 

            if (m.Move(Direction.backward))

            {

                //move was success

                //recurse

                Point new_location = new Point(location.X, location.Y - 1);

                visited[new_location] = new object();

                result = result || CanEscapeHelper(m, visited, new_location);

                if (result) return true; //we found a path return without recursing

                m.Move(Direction.forward); //move the state of the maze back to location

            }

            else

            {

                //move failed

                Point new_location = new Point(location.X, location.Y - 1);

                visited[new_location] = new object();

            }

 

            if (m.Move(Direction.right))

            {

                //move was success

                //recurse

                Point new_location = new Point(location.X + 1, location.Y);

                visited[new_location] = new object();

                result = result || CanEscapeHelper(m, visited, new_location);

                if (result) return true; //we found a path return without recursing

                m.Move(Direction.left); //move the state of the maze back to location

            }

            else

            {

                //move failed

                //record 

                Point new_location = new Point(location.X + 1, location.Y);

                visited[new_location] = new object();

            }

 

            if (m.Move(Direction.forward))

            {

                //move was success

                //recurse

                Point new_location = new Point(location.X, location.Y + 1);

                visited[new_location] = new object();

                result = result || CanEscapeHelper(m, visited, new_location);

                if (result) return true; //we found a path return without recursing

                m.Move(Direction.backward); //move the state of the maze back to location

            }

            else

            {

                //move failed

                Point new_location = new Point(location.X, location.Y + 1);

                visited[new_location] = new object();

            }

            return result;

        }


