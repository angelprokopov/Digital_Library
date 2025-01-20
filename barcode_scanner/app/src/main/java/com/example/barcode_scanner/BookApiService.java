package com.example.barcode_scanner;
import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Path;

public interface BookApiService {
    @GET("api/Books/{isbn}")
    Call<Book> getBoobByISBN(@Path("isbn") String isbn);
}
