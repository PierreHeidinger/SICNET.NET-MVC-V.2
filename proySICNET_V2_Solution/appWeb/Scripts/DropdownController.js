


angular.module('MyApp').controller('DropdownController', function ($scope, StateService) {
    //create a angular controller  
    // expained about controller in Part2 // Here LocationService (Service) Injected

    $scope.departamentoId = null;
    $scope.DistritoId = null;
    $scope.DepartamentoList = null;
    $scope.StateList = null;

    $scope.StateTextToShow = "Select State";
    $scope.Result = "";

    // Populate Country list using GetCountry()
    StateService.getDepartamentos().then(function (d) {
        //assign countries to $scope.CountryList
        $scope.DepartamentoList = d.data;    //success
    },
    function (error) {
        alert('Error!');    //throws error for failure
    });
    // This function to Populate State 
    // it is called after selecting country from dropdownlist
    $scope.GetState = function () {
        $scope.StateID = null; // Clear Selected State if any
        $scope.StateList = null; // Clear previously loaded state list
        $scope.StateTextToShow = "Please Wait..."; // this will show until load states from database

        //Load State 
        StateService.GetState($scope.CountryID).then(function (d) {
            $scope.StateList = d.data;
            $scope.StateTextToShow = "Select State";
        }, function (error) {
            alert('Error!');
        });

    }
    // Function for show result
    //it will be displayed after clicking on button
    $scope.ShowResult = function () {
        $scope.Result = "Selected Country ID : " + $scope.departamentoId + " State ID : " + $scope.StateID;
    }

})
.factory('StateService', function ($http) { //factory methos to get data from server.
    var fac = {};
    fac.getDepartamentos = function () {
        return $http.get('/Clientes/GetDepartamentos')
    }
    fac.GetState = function (countryID) {
        return $http.get('/Home/GetStates?countryID=' + countryID)
    }

    return fac;
});