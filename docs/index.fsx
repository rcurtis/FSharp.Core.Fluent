(**

FSharp.Core.Fluent is a collection of inlined methods allowing fluent access
to all FSharp.Core functions for List, Array, Array2D, Array3D, Seq, Event and Observable.

*)

(**


This library adds ``.map``, ``.filter`` and many other methods for lists, arrays and sequences:

*)

open FSharp.Core.Fluent

let xs = [ 1 .. 10 ]

xs.map(fun x -> x + 1).filter(fun x -> x > 4).sort()

xs.map(fun x -> x + 1)
  .filter(fun x -> x > 4)
  .sort()

(**
## Comparison with non-Fluent style

F# code normally uses curried module functions to access functionality for collections,
composed in pipelines:

    xs
    |> List.map (fun x -> x + 1)
    |> List.filter (fun x -> x > 4)

There are reasons F# uses this style of programming by default:
for example, module functions can compose nicely (e.g. `xs |> List.map (List.map f)`  ).
However "fluent" access can be convenient, especially in rapid investigative programming
against existing data. For this reason, this option makes fluent notation an option.

In almost all case, `xs.OP(arg)` is equivalent to the pipelined `xs |> Coll.OP arg`. So
you can freely interconvert betweeen

*)

xs
|> List.map (fun x -> x + 1)
|> List.filter (fun x -> x > 4)

(** and *)

xs.map(fun x -> x + 1)
  .filter(fun x -> x > 4)

(**

You can also use pipeline operations after fluent operations:

*)
xs
  .map(fun x -> x + 1)
  |> List.filter(fun x -> x > 4)
  |> Array.ofList

(**

However you can't shift from pipelining back to fluent, and attempting to do so can give obscure errors:

```
xs
  |> List.map(fun x -> x + 1)
  .filter(fun x -> x > 4)  // ERROR: The field or constructor "filter" is not defined
```

As an aside, it is worth noting that in the the case of `xs.append(ys)`, the result is "`xs` then `ys`" - as expected.
However this is different to the pitfall ``xs |> List.append ys``, which is actually `ys` then `xs` due to the way
pipelining and currying works.


*)


(**

## Usage examples

See [this documentation](Fluent.html) for examples of using a wide range of the functions.


Contributing and copyright
--------------------------

The project is hosted on [GitHub][gh] where you can [report issues][issues], fork
the project and submit pull requests.

The library is available under Apache 2.0 license, which allows modification and
redistribution for both commercial and non-commercial purposes. For more information see the
[License file][license] in the GitHub repository.

  [content]: https://github.com/fsprojects/FSharp.Core.Fluent/tree/master/docs/content
  [gh]: https://github.com/fsprojects/FSharp.Core.Fluent
  [issues]: https://github.com/fsprojects/FSharp.Core.Fluent/issues
  [readme]: https://github.com/fsprojects/FSharp.Core.Fluent/blob/master/README.md
  [license]: https://github.com/fsprojects/FSharp.Core.Fluent/blob/master/LICENSE.txt

 *)
