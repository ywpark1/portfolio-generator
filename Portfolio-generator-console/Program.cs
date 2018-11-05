using System;

namespace Portfolio_generator_console {

    class Program {
        static void Main (string[] args) {
            HtmlGenerator.SelectTemplate ();
            HtmlGenerator.generateHtml ();
        }
    }
}