var express = require('express');
var router = express.Router();

/* GET users listing. */
router.get('/', function(req, res, next) {
  res.send('respond with a resource');
});

module.exports = router;

// AIzaSyBJp9ykZb4bJOh6J85B9bkAzasOui5JNbI
// https://www.googleapis.com/books/v1/volumes?q=harry+potter&fields=items(volumeInfo(title,authors/*,publisher,publishedDate,description,pageCount,categories/*,averageRating,ratingsCount,imageLinks/*,language))&printType=books&startIndex=0