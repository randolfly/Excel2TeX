﻿namespace Excel2TeX.Model;

public class Setting(Table table)
{
    public Table Table { get; } = table;
    private const string TeXConfig = """
\usepackage[table]{xcolor}
\usepackage{multirow}
\usepackage{colortbl}
\usepackage{dashrule}
\usepackage{ehhline}

%% nested tabular
\newcommand{\minitab}[2][l]{\begin{tabular}{@{}#1@{}}#2\end{tabular}}

%% vertical line
% vertical colored line #1 color #2 width
\newcommand{\vsl}[2]{\color{#1}\vrule width #2}
% doubled vline
% #1 first color #2 first width #3 sep #4 second color #5 second sep
\newcommand{\dvsl}[5]{%
  \vsl{#1}{#2}\hspace{#3}\vsl{#4}{#5}%
}

%% horizontal line
% colored solid line pattern
% #1 color #2 width #3 height
\newcommand{\hsp}[3]{\hbox{\textcolor{#1}{\rule{#2}{#3}}}}
% colored dash line pattern
% #1 color #2 width #3 height #4 style
\newcommand{\hdp}[4]{\hbox{\textcolor{#1}{\hdashrule{#2}{#3}{#4}}}}
% fill line
% #1 top fill #2 bottom fill
\newcommand{\leaderfill}[1]{%
  \xleaders\hbox{%
    \vbox{\baselineskip=0pt\lineskip=0pt#1}%
  }\hfill%
}
% top: solid, bottom: solid
% #1 top color #2 top height #3 bottom color#4 bottom height
\newcommand{\ssfill}[4]{%
  \leaderfill{\hsp{#1}{0.1pt}{#2}\hsp{#3}{0.1pt}{#4}}%
}
% top: solid, bottom: dashed
% #1 top color, #2 top height, #3 common width to expand
% #4 bottom color #5 bottom height, #6 bottom dash line style
\newcommand{\sdfill}[6]{%
  \leaderfill{\hsp{#1}{#3}{#2}\hdp{#4}{#3}{#5}{#6}}%
}
% single solid
% #1 color #2 height
\newcommand{\sfill}[2]{%
  \leaderfill{\hsp{#1}{0.1pt}{#2}}%
}
% single dash
% #1 color #2 width #3 height #4 style
\newcommand{\dfill}[4]{%
  \leaderfill{\hdp{#1}{#2}{#3}{#4}}%
}
""";

    private string SetColor(string color) => $"\\definecolor{@color}{{HTML}}{@color}\n";
    private string GetColor(List<string> colors)
    {
        var res = "";
        foreach (var color in colors)
        {
            res += SetColor(color);
        }
        return res;
    }

    public void OutputSetting(List<string> colors)
    {
        var setting = TeXConfig + GetColor(colors);
        // TODO write file
    }
}
