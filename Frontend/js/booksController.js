app.controller('booksController', function($scope, $rootScope, $http) {
    $scope.booksData = [];
    $rootScope.selectedBook = [];
    $scope.isBookSelected = false;
    $scope.toggle = "Open";
    $http.get("https://localhost:44353/api/books").then(function(response) {
        $scope.booksData = response.data;
    })

    $scope.setBooks = function() {
        $http.get("https://localhost:44353/api/books").then(function(response) {
            $scope.booksData = response.data;
            $scope.isBookSelected = false;
            $scope.toggle = "Open";
        })
    }

    $scope.getBook = function(x) {
        $scope.bookData = [];
        $rootScope.selectedBook = x;
        $scope.isBookSelected = true;
        $scope.toggle = "Close";


    }
    $scope.sendBook = function(title, author, publisher, releaseDate, pages) {
        var data = {
            title: title,
            author: author,
            publisher: publisher,
            releaseDate: releaseDate,
            pages: Number(pages)
        }
        $http.post("https://localhost:44353/api/books/add", JSON.stringify(data)).then(function(response) {
            if (response.data)

                console.log("Post Data Submitted Successfully!");

        }, function(response) {

            console.log("Error");

        });




    }

});