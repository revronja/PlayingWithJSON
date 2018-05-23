package main

import (
	"fmt"
	"os"
	"flag"
)

func main() {

	args := os.Args[1:]
	i := len(args)
	switch i {
    case 1:
        fmt.Println("i = %d%s", i, args)
    case 0:
        fmt.Println("missing arguments try -h or -word")
		break

    }

	flag.String("word", "foo", "a string")
	flag.Parse()

	// channels r typed by the values they convey
	messages := make(chan string)

	 go func() { messages <- "ping" }()

	 msg := <-messages
     fmt.Println(msg)
}
