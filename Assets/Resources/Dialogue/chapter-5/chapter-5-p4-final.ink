-> start

=== start ===
speaker: Warga
Mau ngomong apa sih?
Lama sekali. Sibuk, nih, mau ke ladang.

#speaker: Pemain
#portrait: main-character/mc-smile2
Bapak Ibu sekalian, tolong tenang dan dengarkan dulu. Ini penting.
#portrait: main-character/mc-smile
Pertama-tama, saya tegaskan dulu kalau kabar yang beredar belakangan ini, yang menuduh Pak Kades mengkorupsi anggaran desa, itu tidak benar.

#speaker: Warga
#portrait: npc-cowok/cowo-flat
Halah, enggak usah sok ngebela Bapakmu.
#portrait: npc-cowok/cowo-talk
Mana buktinya?

-> option_1

=== option_1 ===

#speaker: Pemain
Ini, saya punya buktinya.

+ [Anggaran Desa]
    -> bukti_1

+ [Botol berisi Air Sumur]
    -> item_salah_1

+ [Pestisida Biru]
    -> item_salah_1

+ [Pestisida Hijau]
    -> item_salah_1

+ [Buku Kas Pak Udin]
    -> item_salah_1

+ [Kunci Cadangan Gudang Pak Udin]
    -> item_salah_1
    
=== item_salah_1 ===
#speaker: Abdul
#portrait: main-character/mc-serious
(Enggak, bukan yang ini.)
(Ada bukti lain yang lebih cocok.)
-> option_1

=== bukti_1 ===
#illust: items/anggaran-desa
…
#dialogue-box: show

#speaker: Abdul
#portrait: main-character/mc-smile
Ini map anggaran desa yang selama ini disusun Pak Kades.
#portrait: main-character/mc-smile2
Disini tertulis jelas semua alokasi anggaran dengan terperinci, hingga biaya yang terkecil sekalipun.
#portrait: main-character/mc-smile
Bapak Ibu bisa mengecek sendiri isinya jika tidak percaya.
#portrait: main-character/mc-smile3
Selama ini, semua biaya sudah diarahkan untuk membeli peralatan baru untuk warga.
#portrait: main-character/mc-smile2
Pupuk, tanah, bibit, cangkul, bahkan sarung tangan dan sepatu bot.

#speaker: Warga
#portrait: npc-cowok/cowo-flat
Ah, mana mungkin! Nipu itu anggarannya.

#speaker: Abdul
#portrait: main-character/mc-smile
Coba ingat kembali kondisi kebun dan ladang Bapak Ibu sekalian.
#portrait: main-character/mc-smile2
Apa ada peralatan yang rusak atau kurang? Apa Bapak dan Ibu pernah kekurangan pupuk atau bibit?

#speaker: Warga 
#portrait: npc-cewek/cewe-smile
Eh, kalau diingat-ingat...
Iya juga, ya. Udah lama sekali aku gak ke toko bangunan untuk beli peralatan.

#speaker: Abdul
#portrait: main-character/mc-smile
Pak, Bu. Pak Kades sudah mengalokasikan anggaran khusus untuk memastikan Bapak dan Ibu punya peralatan lengkap dan bagus untuk bertani atau berkebun.
Bapak dan Ibu mungkin enggak menyadarinya karena sudah terbiasa, padahal selama ini Pak Kades selalu berusaha mengurus semuanya di balik layar demi kebaikan Bapak dan Ibu sekalian.

#speaker: Warga
#portrait: npc-cowok/cowo-flat
Ah, tapi tetap saja! Sekarang banyak warga yang sakit, tapi Pak Kades enggak pernah bantu, tuh!

#speaker: Abdul
#portrait: main-character/mc-serious
Bukan begitu, Pak, Bu.

#speaker: Pak Kepala Desa
#portrait: pak-kades/kades-smile
Tunggu, Abdul. Biar Bapak yang jelaskan.
#portrait: pak-kades/kades-relieved
Bapak Ibu sekalian, saya sebagai Kades benar-benar minta maaf karena kurang maksimal memberi bantuan pada warga yang sakit.
#portrait: pak-kades/kades-smile
Tapi tidak perlu khawatir.
#portrait: pak-kades/kades-serious
Saya sudah menemukan penyebabnya dan cara menghentikan rantai penyakit ini.
#portrait: pak-kades/kades-relieved
Sebelum itu, Pak Udin, boleh saya tanya sesuatu?

#speaker: Pak Udin
#portrait: pedagang/pedagang-shock
Eh- I-Iya, ada apa?

#speaker: Pak Kepala Desa
#portrait: pak-kades/kades-smile
Pak, saya sangat berterima kasih atas bantuan Bapak selama ini. Kalau boleh, saya mau minta Bapak cerita sedikit supaya warga lain juga tahu seberapa besar usaha Bapak untuk desa ini.
Obat-obatan yang Bapak pakai untuk mengobati warga, boleh saya tahu jenis apa itu dan darimana Bapak mendapatkannya?

#speaker: Pak Udin
#portrait: pedagang/pedagang-laugh
Oalah, itu, toh!
#portrait: pedagang/pedagang-talking
Itu saya kerjasama sama teman apoteker saya di kota.
Jenisnya yahh, pokoknya cocok, deh, sama gejala penyakit warga. Saya udah konsultasi sama teman apoteker saya itu.

#speaker: Pak Kepala Desa
#portrait: pak-kades/kades-smile
Oh, begitu.
Sejak kapan kerjasama itu dimulai, Pak?

#speaker: Pak Udin
#portrait: pedagang/pedagang-talking
Kalau enggak salah, sih, dua bulan yang lalu mungkin.

#speaker: Pak Kepala Desa
#portrait: pak-kades/kades-smile
Oh, sudah lumayan lama.
Hebat sekali, ya. Bisa kerjasama dengan teman apoteker di kota.
Berarti obat-obatannya Bapak beli dengan harga murah, ya?

#speaker: Pak Udin
#portrait: pedagang/pedagang-laugh
Oh, iya, dong! Saya dikasih harga spesial karena kami teman, hahah!

#speaker: Pak Kepala Desa
#portrait: pak-kades/kades-smile
Wah, hebat.
#portrait: pak-kades/kades-serious
Kalau begitu, Pak, berapa keuntungan yang Bapak dapat dari menjual obat-obatan itu ke warga?

#speaker: Pak Udin
#portrait: pedagang/pedagang-shock
E-Eh? Ah, maksudnya?
#portrait: pedagang/pedagang-sad
S-Saya enggak ambil keuntungan, kok. Semua obatnya saya jual murah.

#speaker: Pak Kepala Desa
#portrait: pak-kades/kades-smile
Oh. Saya cuma nanya, kok, Pak.
Jadi Bapak sebenarnya paham, kan, obat apa yang Bapak jual?

#speaker: Pak Udin
#portrait: pedagang/pedagang-talking
Oh, ya, jelas. Kan saya sudah konsultasi dengan teman apoteker saya.
#portrait: pedagang/pedagang-laugh
Aduh, udah deh, Pak, ngebahas soal saya terus. Saya jadi malu, haha.
#portrait: pedagang/pedagang-talking
Coba bahas itu aja, apa tadi? Penyebab penyakit warga.

#speaker: Warga
#portrait: npc-cowok/cowo-talk
Iya, iya!
Apa sih, dari tadi basa-basi mulu.
#portrait: npc-cowok/cowo-flat
Semuanya juga udah tau, kok, kalau Pak Udin itu baik!

#speaker: Pak Kepala Desa
#portrait: pak-kades/kades-smile
Oke.
#portrait: pak-kades/kades-relieved
Abdul. Bisa kamu tunjukkan apa yang jadi sumber penyakit warga?

-> option_2

=== option_2 ===

#speaker: Pemain
Ini.

+ [Anggaran Desa]
    -> item_salah_2

+ [Botol berisi Air Sumur]
    -> bukti_2

+ [Pestisida Biru]
    -> item_salah_2

+ [Pestisida Hijau]
    -> item_salah_2

+ [Buku Kas Pak Udin]
    -> item_salah_2

+ [Kunci Cadangan Gudang Pak Udin]
    -> item_salah_2
    
=== item_salah_2 ===
#speaker: Abdul
#portrait: main-character/mc-serious
(Enggak, bukan yang ini.)
(Ada bukti lain yang lebih cocok.)
-> option_2

=== bukti_2 ===
#illust: items/air-sumur
…
#dialogue-box: show

#speaker: Abdul
#portrait: main-character/mc-smile
Botol ini berisi air sumur desa yang saya ambil seminggu yang lalu sebelum sumur ditutup.
Air sumur ini tercemar. Makanya itu, warga yang bergantung pada sumur desa banyak yang sakit. Diare dan mual-mual.
Lihat, seminggu ini setelah sumur ditutup, tidak ada lagi, kan, warga yang tiba-tiba sakit?

#speaker: Warga
#portrait: npc-cowok/cowo-flat
Ya terus kalau sumurnya tercemar, dibersihkan aja, dong!
#portrait: npc-cewek/cewe-smile
Ngapain sih, ditutup. Jadi nyusahin, kan.

#speaker: Pak Kepala Desa
#portrait: pak-kades/kades-serious
Tidak. Justru sumurnya harus ditutup. 
Karena di desa ini ada seseorang yang sengaja mencemari sumur kita.

#speaker: Warga
#portrait: npc-cewek/cewe-smile
Hah?! Siapa?

#speaker: Pak Udin
#portrait: pedagang/pedagang-shock
...!

#speaker: Pak Kepala Desa
#portrait: pak-kades/kades-relieved
Abdul, tolong tunjukkan sumber pencemaran sumur, Nak.

-> option_3

=== option_3 ===

#speaker: Pemain
Iya, Pak.

+ [Anggaran Desa]
    -> item_salah_3

+ [Botol berisi Air Sumur]
    -> item_salah_3

+ [Pestisida Biru]
    -> bukti_3

+ [Pestisida Hijau]
    -> item_salah_3

+ [Buku Kas Pak Udin]
    -> item_salah_3

+ [Kunci Cadangan Gudang Pak Udin]
    -> item_salah_3
    
=== item_salah_3 ===
#speaker: Abdul
#portrait: main-character/mc-serious
(Enggak, bukan yang ini.)
(Ada bukti lain yang lebih cocok.)
-> option_3

=== bukti_3 ===
#illust: items/pestisida-x
…
#dialogue-box: show

#speaker: Abdul
#portrait: main-character/mc-serious2
Ini-

#speaker: Pak Udin
#portrait: pedagang/pedagang-mad
Hah, itu?!

#speaker: Abdul
#portrait: main-character/mc-serious
Oh? Kenapa, Pak? Bapak tahu ini apa?

#speaker: Pak Udin
#portrait: pedagang/pedagang-shock
E-Eh, ah, e-enggak kok. Enggak tahu saya.

#speaker: Abdul
#portrait: main-character/mc-serious
Oh. Kalau begitu biar saya jelaskan.
Ini adalah pestisida sintetis.
#portrait: main-character/mc-serious2
Kira-kira satu minggu yang lalu, saya melihat Pak Udin membuang botol kosong ini di semak-semak belakang rumahnya.
Beberapa hari sebelumnya, saya pun melihat beliau beberapa kali berdiri di sekitar sumur desa saat hari masih subuh.

#speaker: Pak Udin
#portrait: pedagang/pedagang-mad
Hah?! Bohong!! Apa sih?! Jangan asal tuduh kamu, ya!!

#speaker: Abdul
#portrait: main-character/mc-smile
Saya akan membiarkan warga menilai sendiri.
Silahkan, coba cium bau air sumur ini dan bandingkan dengan bau pestisida pada botol ini.

#speaker: Warga
#portrait: npc-cewek/cewe-smile
Wah, mirip, sih, ini.
Pantesan kayaknya air sumur kemarin baunya familiar.

#portrait: npc-cowok/cowo-talk
Eh, tapi masa sih, Pak Udin...?
Aduh, gak mungkin, gak sih?

#speaker: Pak Udin
#portrait: pedagang/pedagang-mad
Enggak!! Jangan percaya dia!
Mana buktinya?! Enggak ada orang lain yang lihat, kan?!
Saya gak tahu apa itu! Itu bukan punya saya!!

#speaker: Ibu Nanan
#portrait: ibu-ibu/ibu-mad2
Ah, masih berani mengelak, kamu?!

#speaker: Abdul
#portrait: main-character/mc-smile2
Bu Nanan..

#speaker: Ibu Nanan
#portrait: ibu-ibu/ibu-mad2
Kalian semua juga bodoh, gampang sekali percaya!
Mikir, dong!
#portrait: ibu-ibu/ibu-mad
Mana ada lagi orang di desa ini yang mau berurusan sama pestisida sintetis gitu.

#speaker: Pak Udin
#portrait: pedagang/pedagang-mad
Ah, jangan asal ngomong ya, Bu!! Saya- saya cuma pedagang mana paham soal pestisida gini!

#speaker: Pak Kepala Desa
#portrait: pak-kades/kades-serious
Loh? Enggak paham soal pestisida, Pak?
Tapi sudah jelas kalau warga kita sakit karena keracunan pestisida yang tercampur air sumur.
#portrait: pak-kades/kades-mad
Kalau Bapak enggak paham soal pestisida, gimana mungkin Bapak tahu apa gejala keracunan sekaligus obat untuk mengobatinya?
Apa selama ini Bapak asal-asalan memberi obat?

#speaker: Pak Udin
#portrait: pedagang/pedagang-sad2
Eh! E-Enggak, bukan itu maksud saya!
Anu, ah, teman saya! Kan teman apoteker saya yang cerita gejala sekaligus obatnya!

#speaker: Ibu Nanan
#portrait: ibu-ibu/ibu-fierce2
Cari alasan aja terus.
Gejala keracunan pestisida dan obat untuk mengobatinya itu spesifik sekali. Mana bisa dapat obat yang tepat tanpa harus dibawa langsung pasiennya untuk dicek dokter.
#portrait: ibu-ibu/ibu-fierce
Kecuali kalau pestisida dan obat penawar racunnya itu udah disiapkan sekaligus.

#speaker: Warga
#portrait: npc-cowok/cowo-talk
Eh? Serius, nih?
#portrait: npc-cewek/cewe-smile
Beneran Pak Udin??
#portrait: npc-cowok/cowo-talk
Ah enggak, aku enggak percaya.
#portrait: npc-cewek/cewe-smile
Tapi masuk akal loh!

#speaker: Ibu Nanan
#portrait: ibu-ibu/ibu-mad2
Ah, kalian semua juga sama aja!
Udah berapa tahun kalian berkebun sama seperti saya, masa enggak ada yang curiga sama bau air sumur yang jelas-jelas mirip bau pestisida?!
Gak ada yang curiga kenapa banyak warga tiba-tiba kena gejala keracunan?!
Gak ada yang curiga waktu Pak Udin kebetulan punya obat?!
Ketipu kalian sama muka baiknya, iya?!

#speaker: Warga
#portrait: npc-cewek/cewe-smile
Sebenarnya sempat curiga, sih....

#speaker: Pak Udin
#portrait: pedagang/pedagang-sad2
Bapak Ibu, kalian percaya tuduhan ini?!
Saya... Saya bersumpah saya enggak tahu apa-apa!
Ini... Ini pasti jebakan, nih!! Mereka pasti mau ngejebak saya!

#speaker: Abdul
#portrait: main-character/mc-serious
Pak, buktinya sudah jelas.
Lalu Bapak sendiri yang bilang kalau Bapak kerjasama dengan teman apoteker Bapak itu sekitar dua bulan yang lalu.
Kebetulan sekali, ya, warga pun mulai sakit-sakitan di waktu itu juga.

#speaker: Pak Udin
#portrait: pedagang/pedagang-sad2
Enggak, bukan begitu...!!

#speaker: Pak Kepala Desa
#portrait: pak-kades/kades-serious
Semuanya, tolong tenang dulu.
Masih ada hal lain yang harus saya bahas.
Soal kerugian penjualan panen. Saya pun yakin kalau ini karena Pak Udin.

#speaker: Pak Udin
#portrait: pedagang/pedagang-mad
...!!!

#speaker: Pak Kepala Desa
#portrait: pak-kades/kades-serious
Sebagai bukti-

#speaker: Ibu Nanan
#portrait: ibu-ibu/ibu-mad2
Ah, lama! Gak usah pakai bukti juga, kalau dipikir pakai otak sedikit pun kalian harusnya paham!

#speaker: Pak Kades
#portrait: pak-kades/kades-dissapointed
Bu Nanan, tenang dulu!

#speaker: Ibu Nanan
#portrait: ibu-ibu/ibu-mad2
Enggak, saya mau ngomong!
Dengar ya, semuanya! Udah jelas-jelas kalian mulai rugi sejak ngasih hak jual panen ke si Udin.
Kok, masih ngeyel mau percaya saya dia?!

#speaker: Warga
#portrait: npc-cowok/cowo-talk
Bu Nanan! Lancang sekali-

#speaker: Ibu Nanan
#portrait: ibu-ibu/ibu-mad2
Apa?! Gak suka?! Kalau kalian tersindir, ya berarti kalian juga tahu kalau omongan saya ini ada benarnya, kan?!
Harusnya kalian malu!!!
Lucu sekali. Dikasih kemudahan dikit, langsung manja. Dulu kita semua memang capek sekali jualan ke kota, tapi uang kita itu semuanya murni hasil jerih payah kita sendiri!
Semua capek itu terbayar. Kita enggak pernah rugi sampai segininya!!
#portrait: ibu-ibu/ibu-mad
Sekarang lihat diri kalian. Cuma karena dipermudah dikit, dibantu menjualkan hasil panen, dimanja dikasih sembako gratis, macem-macem, eh langsung enggak mau usaha lagi! Lemah!
Udah lama sekali saya tahan-tahan emosi ini karena saya belum punya bukti yang bisa buat kalian sadar.
#portrait: ibu-ibu/ibu-mad2
Kalian mau bukti? Ada!
Abdul, cepat tunjukkan ke mereka!

-> option_4

=== option_4 ===

#speaker: Pemain
Ini buktinya.

+ [Anggaran Desa]
    -> item_salah_4

+ [Botol berisi Air Sumur]
    -> item_salah_4

+ [Pestisida Biru]
    -> item_salah_4

+ [Pestisida Hijau]
    -> item_salah_4

+ [Buku Kas Pak Udin]
    -> bukti_4

+ [Kunci Cadangan Gudang Pak Udin]
    -> item_salah_4
    
=== item_salah_4 ===
#speaker: Abdul
#portrait: main-character/mc-serious
(Enggak, bukan yang ini.)
(Ada bukti lain yang lebih cocok.)
-> option_4

=== bukti_4 ===
#illust: items/buku-kas
…
#dialogue-box: show

#speaker: Abdul
#portrait: main-character/mc-serious2
Ini. Buku kas milik Pak Udin.

#speaker: Pak Udin
#portrait: pedagang/pedagang-mad
...?!
Buku saya! Maling kamu, ya?!!

#speaker: none
#portrait: none
(Pak Udin berusaha merebut bukunya, tapi langsung dicegat oleh Pak Kades dan beberapa warga lainnya.)

#speaker: Ibu Nanan
#portrait: ibu-ibu/ibu-fierce
Nah. Udah ngaku dia kalau itu bukunya.
Sekarang, Abdul. Cepat bacakan isinya.

#speaker: Pak Udin
#portrait: pedagang/pedagang-mad
Enggak!! Enggak, jangan!!

#speaker: Abdul
#portrait: main-character/mc-serious2
Disini tercatat semua pemasukan dan pengeluaran Pak Udin.
#portrait: main-character/mc-serious
Saya enggak akan baca panjang-panjang. Kita langsung lihat intinya saja.
#portrait: main-character/mc-serious2
Pak Ari, boleh saya tahu, di musim panen yang lalu, berapa uang yang Bapak dapat dari Pak Udin?

#speaker: Pak Ari
#portrait: npc-cowok/cowo-talk
Eh? Hmm, mungkin sekitar... dua atau tiga juta...?

#speaker: Abdul
#portrait: main-character/mc-serious2
Pak, disini dicatat penjualan panen Bapak di musim lalu itu lima juta lebih. Jika ditambah dengan beberapa hasil kebun Bapak, hasilnya bisa sampai tujuh juta.

#speaker: Pak Ari
#portrait: npc-cowok/cowo-talk
...!!!

#speaker: Abdul
#portrait: main-character/mc-serious
Selanjutnya, Bu Selly, bagaimana?

#speaker: Ibu Selly
#portrait: npc-cewek/cewe-smile
Saya!! Saya cuma terima sekitar tiga juta! Itupun dipotong hampir sejuta karena macam-macam alasan dari Pak Udin...

#speaker: Abdul
#portrait: main-character/mc-serious2
Padahal hasil kebun Ibu macam-macam sekali... Dari yang tertulis disini, harusnya Ibu bisa mendapat sampai enam juta lebih...

#speaker: none
#portrait: none
(Abdul membacakan hasil panen warga satu per satu.)
(Semakin lama, semakin tampak jelas berapa banyak uang yang telah dikorupsi oleh Pak Udin.)
(Beberapa warga mulai memberontak dan memaki Pak Udin. Beberapa menangis karena merasa tertipu dan kecewa.)
(Pak Udin masih dengan sombongnya tidak mau mengakui semua kesalahannya. Ia mencoba kabur, tapi ditahan oleh warga.)

#speaker: Pak Udin
#portrait: pedagang/pedagang-mad
Bohong! Ini semua bohong!!
#portrait: pedagang/pedagang-sad2
Pak, Bu, percaya sama saya!! Kan selama ini saya sudah banyak sekali membantu kalian!!
Kalian lebih percaya sama mereka ini??

#speaker: Pak Kepala Desa
#portrait: pak-kades/kades-mad
Cukup, Pak.
Saya sudah lihat sendiri.
Sembako yang Bapak bagikan ke warga rata-rata sudah hampir kadaluwarsa. Sudah tidak layak untuk dikonsumsi!! 
Bukannya membantu, Bapak cuma membuat desa ini semakin terpuruk!

#speaker: Pak Udin
#portrait: pedagang/pedagang-sad
B-Bapak salah lihat!
Lagipula, saya enggak pernah korupsi!!! Saya enggak punya uang sebanyak itu!
Semua warga setiap hari selalu bebas keluar masuk rumah saya, kan?! Mau dimana saya simpan uang sebanyak itu?!

#speaker: Pak Kepala Desa
#portrait: pak-kades/kades-serious
Tenang saja. Akan kami cari sendiri.
Abdul, keluarkan bukti terakhirnya.

-> option_5

=== option_5 ===

#speaker: Pemain
Ini buktinya.

+ [Anggaran Desa]
    -> item_salah_5

+ [Botol berisi Air Sumur]
    -> item_salah_5

+ [Pestisida Biru]
    -> item_salah_5

+ [Pestisida Hijau]
    -> item_salah_5

+ [Buku Kas Pak Udin]
    -> item_salah_5

+ [Kunci Cadangan Gudang Pak Udin]
    -> bukti_5
    
=== item_salah_5 ===
#speaker: Abdul
#portrait: main-character/mc-serious
(Enggak, bukan yang ini.)
(Ada bukti lain yang lebih cocok.)
-> option_5

=== bukti_5 ===
#illust: items/kunci
…
#dialogue-box: show

#speaker: Abdul
#portrait: main-character/mc-serious2
Ini kunci cadangan gudang Bapak yang disimpan Bu Nanan.

#speaker: Pak Udin
#portrait: pedagang/pedagang-shock
...!
Hah! Silahkan! Coba cek saja! Tidak ada apa-apa disitu!

#event: move-5-? //semua warga ke rumah pak Udin

#speaker: none
#portrait: none
(Semua warga berkumpul di depan rumah Pak Udin.)
(Segera setelah Pak Kades membuka gudang dengan kunci cadangan, warga langsung berbondong-bondong masuk untuk mencari bukti uang mereka yang disimpan Pak Udin.)

#speaker: Abdul
#portrait: main-character/mc-serious2
Tunggu, Pak, Bu!
Tidak perlu mencari ke seluruh rumah. Cukup di gudang saja.

#speaker: Warga
#portrait: npc-cowok/cowo-talk
Hah? Ini cuma gudang barang! Mana ada uang disini!

#speaker: Pak Udin
#portrait: pedagang/pedagang-smile
Kan sudah saya bilang-!

#speaker: Abdul
#portrait: main-character/mc-serious
Bukan disini. Coba cek di loteng.

#speaker: Pak Udin
#portrait: pedagang/pedagang-mad
...!!

#speaker: none
#portrait: none
(Di loteng, warga menemukan berlusin-lusin koper berisi uang. Sangat banyak sampai hampir menutupi loteng.)
(Pak Pedagang tidak bisa berkata-kata lagi dan bersiap untuk kabur, tapi warga langsung menahannya.)

#ending: true

-> END
