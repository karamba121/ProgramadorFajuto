<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class PostController extends Controller
{
    public function Index()
    {
        return view('post.index', $data = [ 'title' => 'Post'

        ]);
    }
}
