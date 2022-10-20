#speaker: Pak Kepala Desa
#portrait: pak-kades/kades-smile
Kamu sudah ambil mapnya?

#event: tutorial-multiple-choice

*[Sudah, Pak]
    -> anggaran
    
*[Belum, Pak]
#speaker: Pak Kepala Desa
#portrait: pak-kades/kades-smile
    Itu mapnya ada di atas meja depan rumah.


=== anggaran ===
#speaker: Abdul
#portrait: main-character/mc-smile
Yang ini, Pak?

*[Tunjukkan Map Anggaran Desa]
    #event: tutorial-open-inventory, chapter-1-p4-kades
    #quest-1-3
    
    #speaker: Pak Kepala Desa
    #portrait: pak-kades/kades-smile
    Iya, benar yang ini.
    Coba kamu lihat dulu isinya.
    Anggaran selama dua tahun belakangan ini sudah Bapak susun rapi disitu.
    
-> END
