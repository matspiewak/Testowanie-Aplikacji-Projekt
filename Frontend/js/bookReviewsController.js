app.controller('bookReviewsController', function($scope, $rootScope, $http) {
    $scope.bookReviewsData = [];
    $scope.init = function() {
        $http.get("https://localhost:44353/api/bookreviews").then(function(response) {
            $scope.bookReviewsData = response.data;
        })

    }
    $scope.sendReview = function(review, rating) {
        var data = {
            title: $rootScope.selectedBook.title,
            review: review,
            rating: Number(rating)
        };
        console.log(data);
        $http.post('https://localhost:44353/api/bookreviews/add', JSON.stringify(data)).then(function(response) {

            if (response.data)

                console.log("Post Data Submitted Successfully!");

        }, function(response) {

            console.log("Error");

        });


    }
});