<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class FerramentasController extends Controller
{
    public function Index()
    {
        return view('ferramentas.index', $data = [ 'title' => 'Ferramentas'

        ]);
    }
}
