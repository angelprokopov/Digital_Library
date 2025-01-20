package com.example.barcode_scanner;

public class Book {
    private int id;
    private String isbn;
    private String title;
    private String author;
    private String genre;
    private String coverUrl;

    public int getId() { return id; }
    public void setId(int id) {this.id = id;}

    public String getIsbn(){return isbn;}
    public void setIsbn(String isbn){this.isbn = isbn;}

    public String getTitle() {return title;}
    public void setTitle(String title) {this.title = title;}

    public String getAuthor() {return author;}
    public void setAuthor(String author) {this.author = author;}

    public String getGenre(){return genre;}
    public void setGenre(String genre) {this.genre = genre;}

    public String getCoverUrl() {return coverUrl;}
    public void setCoverUrl(String coverUrl) {this.coverUrl = coverUrl;}
}
