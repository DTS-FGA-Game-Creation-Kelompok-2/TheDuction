#dialogue-box: show
#speaker: Pak Kepala Desa
#portrait: kades
#bgm: a
#sfx: a
Mana, sudah kamu ambil mapnya?

#event: tutorial-multiple-choice

*[Sudah, Pak]
    -> anggaran
    
*[Belum, Pak]
#speaker: Pak Kepala Desa
    Itu mapnya ada di atas meja depan rumah.


=== anggaran ===
#speaker: Abdul
Yang ini, Pak?

*[Tunjukkan Map Anggaran Desa]
    #event: tutorial-open-inventory
    #event: chapter-1-p4-kades
    #speaker: Pak Kepala Desa
    Iya, benar yang ini.
    Coba kamu lihat dulu isinya.
    Anggaran selama dua tahun belakangan ini sudah Bapak susun rapi disitu.
    
-> END
