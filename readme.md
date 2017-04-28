# Code Highlighter

![](image/Logo.png)

Annotate class, properties or methods with an attribute:

```c#
[Highlight("This code needs to be looked at")]
```

Execute the runner

```
> CodeHighlighter.Runner.exe
```

...and get a summary of the highlights

```text
[Method] Demo.Namespace.Class1.TestMethod "This code needs to be looked at"
  in C:\Code\Demo\Class1.cs
```

## License

MIT
