<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class LoginController extends Controller
{
    public function Index()
    {
        return view('login.index', $data = [ 'title' => 'Login'

        ]);
    }
}
